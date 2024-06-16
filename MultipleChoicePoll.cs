//Christine Liu  X00193365  OOSDEV2-Repeat
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSDEV2
{
    //part 2 as per ExamSheet
    public class MultipleChoicePoll
    {
        private string _title;
        public string Title { get { return _title; } }

        private List<Option> _options;

        private DateOnly _expirationDate;
        public DateOnly ExpirationDate { get { return _expirationDate; } } //req 2.2 as per ExamSheet

        private int _totalVoteCast;

        public MultipleChoicePoll(string PollTitle, DateOnly Deadline)
        {
            if (PollTitle.Length > 30 || !PollTitle.All(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c))) //req 2.1 as per ExamSheet
            {
                throw new ArgumentException("Poll title is limited to 30 alphanumeric characters");
            }
            _title = PollTitle;
            _expirationDate = Deadline;
            _options = new List<Option>();
            _totalVoteCast = 0;
        }

        public int NumberOfOptions { get { return _options.Count(); } } //req 2.4 per ExamSheet

        public void AddOption(Option NewOption) //req 2.3 as per ExamSheet
        {
            _options.Add(NewOption);
        }

        public void VoteFor(int OptionIndex, int NbOfVotes) //req 2.5 per ExamSheet
        {
            if (OptionIndex < 0 || OptionIndex >= _options.Count()) throw new ArgumentOutOfRangeException("Option index out of range");
            _options[OptionIndex].ReceiveVotes(NbOfVotes);
            _totalVoteCast += NbOfVotes;
            UpdatePercentage();
        }

        public Option GetOption(int OptionIndex) //req 2.6
        {
            if (OptionIndex < 0 || OptionIndex >= _options.Count()) throw new ArgumentOutOfRangeException("Option index out of range");
            return _options[OptionIndex];
        }

        public void UpdatePercentage() //req 2.7
        {
            _options.ForEach(opt => opt.UpdatePercentageOfVote(_totalVoteCast));
        }

        public override string ToString()
        {
            string str = $"{Title} ({ExpirationDate.ToString()}) \n";
            _options.ForEach(opt => str += opt.ToString() + "\n");
            return str;
        }
    }
}
