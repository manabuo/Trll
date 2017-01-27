using System.Collections;
using System.Collections.Generic;

namespace Trll.Mobile.Presenters
{
    public class TeamPresenter : IEnumerable<BoardPresenter>
    {
        public string TeamName { get; set; }

        public IEnumerable<BoardPresenter> TeamBoards { get; set; }

        public IEnumerator<BoardPresenter> GetEnumerator() =>
            TeamBoards.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}