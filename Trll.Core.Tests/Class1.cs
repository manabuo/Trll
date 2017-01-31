using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Trll.Core.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public async Task Test()
        {
            var trelloClient = new TrelloClient();

            var me = await trelloClient.CurrentUserProfileAsync();

            Console.WriteLine(me);
        }

        [Test]
        public async Task List()
        {
            var trelloClient = new TrelloClient();

             foreach (var board in (await trelloClient.CurrentUserProfileAsync()).Boards)
             {
                var boards = await trelloClient.ListsByBoardId(board.Id);

                 ;
             }
        }
        [Test]
        public async Task Org()
        {
            var trelloClient = new TrelloClient();

            var org = await trelloClient.Organizations();
            foreach (var organizations in org)
            {
                Console.WriteLine(organizations);
            }
        }
        
        [Test]
        public async Task Checklists()
        {
            var trelloClient = new TrelloClient();

            foreach (var board in (await trelloClient.CurrentUserProfileAsync()).Boards)
            {
                var boards = await trelloClient.ChecklistsByBoardId(board.Id);

                ;
            }
        }
    }
}
