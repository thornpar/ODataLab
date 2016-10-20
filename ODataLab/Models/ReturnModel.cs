using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataLab.Models
{
    public class MyKeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }


    public class ReturnModel
    {
        public ReturnModel()
        {
            //Dynamic = new List<MyKeyValue>();
            dynamicFields = new Dictionary<string, object>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Category { get; set; }
        public IDictionary<string, object> dynamicFields;
        //private List<string> inMemoryList { get; set; }
        /*public IDictionary<string, object> DynamicFields
        {
            get
            {
                dynamicFields = new Dictionary<string, object>();
                var list = DTest.ToList();
                foreach (var v in list)
                {
                    //if(v[0]==null || dynamicFields.ContainsKey(v[0].Replace(".","")))
                    //    continue;

                    //dynamicFields.Add(v[0].Replace(".", ""), (object) v[1]);

                    if (v[0] == null || dynamicFields.ContainsKey(v[0].Replace(".", "")))
                        continue;

                    dynamicFields.Add(v[0].Replace(".", ""), (object)v[1]);

                }
                //  dynamicFields = DTest.ToDictionary(x => x[0]??Guid.NewGuid().ToString(), x => (object)x[1]);
                return dynamicFields;
            }
            set { dynamicFields = value; }
        }*/

        //internal List<List<string>> DTest { get; set; }
    }
}
