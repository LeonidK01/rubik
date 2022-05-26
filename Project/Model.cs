using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Model
    {
        public class Fasad
        {
            public Client_list client_List { get; set; }
            public Car_list car_List { get; set; }
            public Arenda_list arenda_List { get; set; }


            public Fasad()
            {
                this.client_List = Client_list.get_instanse();
                this.car_List = Car_list.get_instanse();
                this.arenda_List = Arenda_list.get_instanse();
            }

            public void create_client_list(Object[] obj)
            {
                client_List.add_el(new client(Convert.ToInt32(obj[0]), obj[1].ToString(), obj[2].ToString(), obj[3].ToString(), obj[4].ToString(), obj[5].ToString()));
            }

            public void update_client_list(Object[] obj)
            {
                client_List.update_el(new client(Convert.ToInt32(obj[0]), obj[1].ToString(), obj[2].ToString(), obj[3].ToString(), obj[4].ToString(), obj[5].ToString()));
            }

            public void create_car_list(Object[] obj)
            {
                car_List.add_el(new car(Convert.ToInt32(obj[0]), obj[1].ToString(), obj[2].ToString(), Convert.ToInt32(obj[3]), obj[4].ToString()));
            }
            public void update_car_list(Object[] obj)
            {
                car_List.update_el(new car(Convert.ToInt32(obj[0]), obj[1].ToString(), obj[2].ToString(), Convert.ToInt32(obj[3]), obj[4].ToString()));
            }

            public void create_arenda_list(Object[] obj)
            {
                arenda_List.add_el(new arenda_(Convert.ToInt32(obj[0]), obj[1].ToString(), obj[2].ToString(), Convert.ToInt32(obj[3]), Convert.ToInt32(obj[4]), Convert.ToInt32(obj[5])));
            }
            public void update_arenda_list(Object[] obj)
            {
                arenda_List.update_el(new arenda_(Convert.ToInt32(obj[0]), obj[1].ToString(), obj[2].ToString(), Convert.ToInt32(obj[3]), Convert.ToInt32(obj[4]), Convert.ToInt32(obj[5])));
            }

            public class client : Id
            {
                public int id_client { get; set; }
                public string name { get; set; }
                public string first_name { get; set; }
                public string last_name { get; set; }
                public string stag { get; set; }
                public string phone { get; set; }

                public client(int Id_client, string Name, string First_name, string Last_name, string Stag, string Phone)
                {
                    id_client = Id_client;
                    name = Name;
                    first_name = First_name;
                    last_name = Last_name;
                    stag = Stag;
                    phone = Phone;
                }
                public int id()
                {
                    return id_client;
                }

                public List<String> mass_s()
                {
                    List<String> array = new List<String>();
                    array.Add(id_client.ToString());
                    array.Add(name);
                    array.Add(first_name);
                    array.Add(last_name);
                    array.Add(stag.ToString());
                    array.Add(phone);
                    return array;
                }
            }

            public class car : Id
            {
                public int id_car { get; set; }
                public string brend { get; set; }
                public string marka { get; set; }
                public int brobeg { get; set; }
                public string class_ { get; set; }

                public car(int Id_car, string Brend, string Marka, int Brobeg, string Class_)
                {
                    id_car = Id_car;
                    brend = Brend;
                    marka = Marka;
                    brobeg = Brobeg;
                    class_ = Class_;
                }
                public int id()
                {
                    return id_car;
                }

                public List<String> mass_s()
                {
                    List<String> array = new List<String>();
                    array.Add(id_car.ToString());
                    array.Add(brend);
                    array.Add(marka);
                    array.Add(brobeg.ToString());
                    array.Add(class_);
                    return array;
                }
            }

            public class arenda_ : Id
            {
                public int id_arenda { get; set; }
                public string data_start { get; set; }
                public string data_end { get; set; }
                public int price { get; set; }
                public int id_client { get; set; }
                public int id_car { get; set; }

                public arenda_(int Id_arenda, string Data_start, string Data_end, int Price, int Id_client, int Id_car)
                {
                    id_arenda = Id_arenda;
                    data_start = Data_start;
                    data_end = Data_end;
                    price = Price;
                    id_client = Id_client;
                    id_car = Id_car;
                }

                public int id()
                {
                    return id_arenda;
                }

                public List<String> mass_s()
                {
                    List<String> array = new List<String>();
                    array.Add(id_arenda.ToString());
                    array.Add(data_start);
                    array.Add(data_end);
                    array.Add(price.ToString());
                    array.Add(id_client.ToString());
                    array.Add(id_car.ToString());
                    return array;
                }
            }

            interface Id
            {
                int id();
            }

            interface InList<T>
            {
                void add_el(T obj);
                void delete_el(int id);
                void update_el(T obj);
                Object select_el(T obj);
                int ret_id();
            }

            public class Client_list : InList<client>
            {
                private int last_id;
                private List<client> client_list;
                private static Client_list one;
                private Client_list()
                {


                    client_list = new List<client>();
                    if (client_list.Count != 0)
                        last_id = client_list[client_list.Count - 1].id();
                    else
                        last_id = 0;
                }
                public static Client_list get_instanse()
                {
                    if (one == null)
                    {
                        one = new Client_list();
                    }
                    return one;
                }
                public void add_el(client client)
                {
                    this.client_list.Add(client);
                }
                public void delete_el(int id)
                {
                    this.client_list.RemoveAll(client => client.id() == id);
                }
                public void update_el(client id)
                {
                    client old_client = this.client_list.Find(client => client.id() == id.id());
                    old_client.id_client = id.id_client;
                    old_client.name = id.name;
                    old_client.first_name = id.first_name;
                    old_client.last_name = id.last_name;
                    old_client.stag = id.stag;
                    old_client.phone = id.phone;
                }
                public Object select_el(client obj)
                {
                    return 1;
                }
                public List<List<string>> mass_client()
                {
                    List<List<string>> mass = new List<List<string>>();
                    foreach (client i in this.client_list)
                    {
                        mass.Add(i.mass_s());
                    }
                    return mass;
                }

                public List<string> get_full_id()
                {
                    List<string> ids = new List<string>();
                    foreach (client i in client_list)
                    {
                        ids.Add(i.id().ToString());

                    }
                    return ids;
                }

                public int ret_id()
                {
                    this.last_id += 1;
                    return this.last_id;
                }


            }

            public class Car_list : InList<car>
            {
                private int last_id;
                private List<car> car_list;
                private static Car_list one;
                private Car_list()
                {
                    car_list = new List<car>();
                    last_id = 0;
                }
                public static Car_list get_instanse()
                {
                    if (one == null)
                    {
                        one = new Car_list();
                    }
                    return one;
                }
                public void add_el(car car)
                {
                    this.car_list.Add(car);
                }
                public void delete_el(int id)
                {
                    this.car_list.RemoveAll(car => car.id() == id);
                }
                public void update_el(car id)
                {
                    car old_car = this.car_list.Find(car => car.id() == id.id());
                    old_car.id_car = id.id_car;
                    old_car.brend = id.brend;
                    old_car.marka = id.marka;
                    old_car.brobeg = id.brobeg;
                    old_car.class_ = id.class_;
                }
                public Object select_el(car obj)
                {
                    return 1;
                }
                public List<List<string>> mass_car()
                {
                    List<List<string>> mass = new List<List<string>>();
                    foreach (car i in this.car_list)
                    {
                        mass.Add(i.mass_s());
                    }
                    return mass;
                }

                public List<string> get_full_id()
                {
                    List<string> ids = new List<string>();
                    foreach (car i in car_list)
                    {
                        ids.Add(i.id().ToString());

                    }
                    return ids;
                }

                public int ret_id()
                {
                    this.last_id += 1;
                    return this.last_id;
                }

            }

            public class Arenda_list : InList<arenda_>
            {
                private int last_id;
                private List<arenda_> arenda_list;
                private static Arenda_list one;
                private Arenda_list()
                {
                    arenda_list = new List<arenda_>();
                    last_id = 0;
                }
                public static Arenda_list get_instanse()
                {
                    if (one == null)
                    {
                        one = new Arenda_list();
                    }
                    return one;
                }
                public void add_el(arenda_ arenda)
                {
                    this.arenda_list.Add(arenda);
                }
                public void delete_el(int id)
                {
                    this.arenda_list.RemoveAll(arenda => arenda.id() == id);
                }
                public void update_el(arenda_ id)
                {
                    arenda_ old_car = this.arenda_list.Find(arenda => arenda.id() == id.id());
                    old_car.id_arenda = id.id_arenda;
                    old_car.data_start = id.data_start;
                    old_car.data_end = id.data_end;
                    old_car.price = id.price;
                    old_car.id_client = id.id_client;
                    old_car.id_car = id.id_car;
                }
                public Object select_el(arenda_ obj)
                {
                    return 1;
                }
                public List<List<string>> mass_arenda()
                {
                    List<List<string>> mass = new List<List<string>>();
                    foreach (arenda_ i in this.arenda_list)
                    {
                        mass.Add(i.mass_s());
                    }
                    return mass;
                }

                public List<string> get_full_id()
                {
                    List<string> ids = new List<string>();
                    foreach (arenda_ i in arenda_list)
                    {
                        ids.Add(i.id().ToString());

                    }
                    return ids;
                }
                public int ret_id()
                {
                    this.last_id += 1;
                    return this.last_id;
                }

            }
            public bool valid_(Object[] obj)
            {
                bool c = true;
                if (this.client_List.get_full_id().Contains(obj[4]))
                    c = false;
                if (this.car_List.get_full_id().Contains(obj[5]))
                    c = false;
                return c;
            }

        }
    }
}
