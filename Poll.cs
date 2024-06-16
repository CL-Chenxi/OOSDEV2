//Christine Liu  X00193365  OOSDEV2-Repeat

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOSDEV2
{
    //part 1 as per ExamSheet
    public class Option
    {   
        //feild to store value
        private string _name;
        //properties offers control of access
        public string Name { get { return _name; } } //req 1.1 as per ExamSheet

        private int _nbVotes;
        public int NbVotes { get { return _nbVotes; } } //req 1.2 as per ExamSheet
        private float _votePercentage;
        public float VotePercentage { get { return _votePercentage; } } //req 1.3 as per ExamSheet

        public Option(string OptionName)
        {
            _name = OptionName;
            _nbVotes = 0;
            _votePercentage = 0;
        }

        public void ReceiveVotes(int NbOfVotes)
        {
            _nbVotes += NbOfVotes;
        }

        public void UpdatePercentageOfVote(int PollTotal)
        {
            if (PollTotal > 0)
            {
                _votePercentage = (_nbVotes / (float)PollTotal) * 100;
            }

        }

        public override string ToString() //req 1.4 as per ExamSheet
        {
            return $"{Name}: {VotePercentage}%";
        }
    }
}
