namespace Task3
{
    public class Employee
    {
        private string _name, _birthday;
        private int _height;
        private double _weight;
        private bool _car;
        private List<string> _languages;

        public Employee(string name, string birthday, int height, double weight, bool car, List<string> languages)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Height = height;
            this.Weight = weight;
            this.Car = car;
            this.Languages = languages;
        }
        private Employee()// не работает deserialize xml без конструктора без парамметров
        {

        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public bool Car
        {
            get { return _car; }
            set { _car = value; }
        }

        public List<string> Languages
        {
            get { return _languages; }
            set { _languages = value; }
        }

        public override string ToString()
        {
            string info = "Имя: " + Name + Environment.NewLine +
                "День рожения: " + Birthday + Environment.NewLine +
                "Рост: " + Height + Environment.NewLine +
                "Вес: " + Weight + Environment.NewLine +
                "Наличие авто: " + Car + Environment.NewLine +
                "Языки: ";
            foreach (string language in Languages)
            {
                info+= language;
            }
            info += Environment.NewLine;
            return info;
        }
    }
}
