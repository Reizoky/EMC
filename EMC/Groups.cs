using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace EMC
{
    public class Groups
    {
        DataSet sdGr = new DataSet();
        public static List<string> namesOfGroups = new List<string>();
        public static Dictionary<string, string> practiceGroup = new Dictionary<string, string>();
        public static Dictionary<string, string> scheduleGroup = new Dictionary<string, string>();
        public static DateTime dateStartSemester;
        public static DateTime dateEndSemester;
    }
}