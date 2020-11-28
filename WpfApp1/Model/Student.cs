using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Student : Interface.NotifyPropertyChanged
    {
        public static string Header
            => "Grade,Class,Name,Number,Score";

        public override string ToString()
        {
            return $"{Grade},{Class},{Name},{Number},{Score}";
        }

        private string grade;
        public string Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
                OnPropertyChanged();
            }
        }

        private string @class;
        public string Class
        {
            get
            {
                return @class;
            }
            set
            {
                @class = value;
                OnPropertyChanged();
            }
        }

        private string number;
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged();
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string score;
        public string Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                OnPropertyChanged();
            }
        }
    }
}
