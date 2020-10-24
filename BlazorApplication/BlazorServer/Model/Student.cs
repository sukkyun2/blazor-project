using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebApplication5.Model
{
    public class Student : INotifyPropertyChanged
    {
        //private Db context;

        private int id; // primary key
        private int? grade; //학년
        private int? cclass; //반?
        private string no; //학번
        private string name; //이름
        private string score; //학점

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            //Debug.WriteLine($"변경감지");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Student() { }

        public Student(int grade, string no, int cclass, string name, string score)
        {
            this.grade = grade;
            this.cclass = cclass;
            this.no = no;
            this.name = name;
            this.score = score;
        }

        public Student(int id, int grade, string no, int cclass, string name, string score)
        {
            this.id = id;
            this.grade = grade;
            this.cclass = cclass;
            this.no = no;
            this.name = name;
            this.score = score;
        }

        /* property */

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int? Grade
        {
            get { return grade; }
            set
            {
                if (value != this.grade)
                {
                    this.grade = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int? Cclass
        {
            get { return cclass; }
            set
            {
                if (value != this.cclass)
                {
                    this.cclass = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string No
        {
            get { return no; }
            set
            {
                if (value != this.no)
                {
                    this.no = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Score
        {
            get { return score; }
            set
            {
                if (value != this.score)
                {
                    this.score = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }

}
