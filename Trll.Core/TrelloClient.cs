using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Trll.Core.Entities;
using static Trll.Core.Constants;

namespace Trll.Core
{
    public class TrelloClient
    {
        private readonly HttpClient _httpClient;

        public TrelloClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<UserProfile> CurrentUserProfileAsync()
        {
            var query = "boards=all&" +
                        "organizations=all&" +
                        "organization_fields=displayName,name,desc&" +
                        "fields=fullName,initials,username,email&" +
                        "board_fields=name,desc,idOrganization,labelNames,prefs";
            var message = await _httpClient
                .GetAsync($"{BaseUrl}/members/me?{query}&token={Token}&key={Key}");

            var result = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserProfile>(result);
        }

        public async Task<IEnumerable<Organization>> Organizations()
        {
            var message = await _httpClient.GetAsync($"{BaseUrl}/members/me/organizations?token={Token}&key={Key}");
            var result = await message.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Organization[]>(result);
        }

        public async Task<IEnumerable<List>> ListsByBoardId(string id)
        {
            var parameters = "&cards=all" +
                             "&fields=name,idBoard" +
                             "&card_fields=desc,idBoard,idList,name,badges,dueComplete,due,labels,idMembers";
            var message = await _httpClient.GetAsync($"{BaseUrl}/boards/{id}/lists?token={Token}&key={Key}{parameters}");

            var result = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<List>>(result);
        }

        public async Task<IEnumerable<Checklist>> ChecklistsByBoardId(string boardId)
        {
            var parameters = "&checkItem_fields=name,state&fields=idBoard,idCard,name";
            var message = await _httpClient.GetAsync($"{BaseUrl}/boards/{boardId}/checklists?token={Token}&key={Key}{parameters}");

            var result = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Checklist>>(result);
        }

        public async Task<MemberInfo> GetMemberInfoAsync(string memberId)
        {
            var parameters = "&fields=initials,fullName,avatarHash";
            var message = await _httpClient.GetAsync($"{BaseUrl}/members/{memberId}?token={Token}&key={Key}{parameters}");

            var result = await message.Content.ReadAsStringAsync();
            var memberInfo = JsonConvert.DeserializeObject<MemberInfo>(result);

            if (!string.IsNullOrEmpty(memberInfo.AvatarHash))
                memberInfo.AvatarBytes =
                    await _httpClient.GetByteArrayAsync(
                        $"http://trello-avatars.s3.amazonaws.com/{memberInfo.AvatarHash}/50.png");

            return memberInfo;
        }
    }
}
