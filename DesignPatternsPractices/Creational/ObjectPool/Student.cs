using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.ObjectPool
{
    public class Student
    {
        public static int ObjectCounter = 0;
        public Student()
        {
            ++ObjectCounter;
        }
        private string _Firstname;
        private string _Lastname;
        private int _RollNumber;
        private string _Class;


        public string Firstname
        {
            get
            {
                return _Firstname;
            }
            set
            {
                _Firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return _Lastname;
            }
            set
            {
                _Lastname = value;
            }
        }

        public string Class
        {
            get
            {
                return _Class;
            }
            set
            {
                _Class = value;
            }
        }

        public int RollNumber
        {
            get
            {
                return _RollNumber;
            }
            set
            {
                _RollNumber = value;
            }
        }
    
}
}
