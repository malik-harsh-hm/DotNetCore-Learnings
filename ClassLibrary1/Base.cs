

namespace ClassLibrary1
{
    public class Base
    {
        public string PublicProp { get; set; }
        private string PrivateProp {  get; set; }
        protected string ProtectedProp { get; set; }
        internal string InternalProp { get; set; }
        protected internal string ProtectedInternalProp { get; set; }

        public Base()
        {
            this.PublicProp = "";
            this.PrivateProp = "";
            this.ProtectedProp = "";
            this.InternalProp = "";
            this.ProtectedInternalProp = "";
        }

    }
    public class Derived1 : Base
    {
        public Derived1()
        {
            this.PublicProp = "";
            this.ProtectedProp = "";
            this.InternalProp = "";
            this.ProtectedInternalProp = "";
        }

    }
    public class MyClass 
    {
        static void Main() {
            Base obj = new Base();
            Console.WriteLine(obj.PublicProp);
            Console.WriteLine(obj.InternalProp);
            Console.WriteLine(obj.ProtectedInternalProp);
        }
    }
}
