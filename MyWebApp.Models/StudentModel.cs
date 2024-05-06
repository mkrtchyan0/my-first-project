using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class StudentModel
    {
        /// <summary>
        /// the private field id
        /// </summary>
        private int id;

        /// <summary>
        /// The private string name
        /// </summary>
        private string name;

        /// <summary>
        /// the private string sureName
        /// </summary>
        private string sureName;

        /// <summary>
        /// the private int age
        /// </summary>
        private int age;

        /// <summary>
        /// the private int points
        /// </summary>
        private int points;


        /// <summary>
        /// Property ID
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value > 0)
                {
                    id = value;
                }
            }
        }

        /// <summary>
        /// Property Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!value.Contains("0") || !value.Contains("1") || !value.Contains("2") || !value.Contains("3") ||
                    !value.Contains("4") || !value.Contains("5") || !value.Contains("6") || !value.Contains("7") ||
                    !value.Contains("8") || !value.Contains("9") || !value.Contains("0"))
                {
                    name = value;
                }
            }
        }
        /// <summary>
        /// Property SureName
        /// </summary>
        public string SureName
        {
            get
            {
                return sureName;
            }
            set
            {
                if (!value.Contains("0") || !value.Contains("1") || !value.Contains("2") || !value.Contains("3") ||
                    !value.Contains("4") || !value.Contains("5") || !value.Contains("6") || !value.Contains("7") ||
                    !value.Contains("8") || !value.Contains("9") || !value.Contains("0"))
                {
                    sureName = value;
                }
            }
        }

        /// <summary>
        /// Property Age
        /// </summary>
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }

        /// <summary>
        /// Prperty Points
        /// </summary>
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                if (value > 0)
                {
                    points = value;
                }
            }
        }
    }
}
