using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace IntegratedGuiV2
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            //GenerateXmlFile();
        }

        static void GenerateXmlFile()
        {
            // 透過反射取得 MainForm 的所有 UserControl 元件
            var userControls = typeof(MainForm).GetNestedTypes().Where(t => t.IsSubclassOf(typeof(UserControl))).ToList();

            // 創建設定對象
            var settings = new Settings
            {
                Components = userControls.Select(uc => new ComponentVisibility { Name = uc.Name, Visible = true }).ToList(),
                Permissions = new List<RolePermission>()
            };

            // 填充角色許可權
            string[] roles = { "Admin", "Engineer", "Operator" };
            foreach (var role in roles)
            {
                settings.Permissions.Add(new RolePermission
                {
                    Role = role,
                    Components = userControls.Select(uc => new ComponentVisibility { Name = uc.Name, Visible = true }).ToList()
                });
            }

            // 使用 XML 序列化儲存 XML 檔案
            var serializer = new XmlSerializer(typeof(Settings));
            using (var writer = new StreamWriter("Settings.xml"))
            {
                serializer.Serialize(writer, settings);
            }

            Console.WriteLine("XML file generated successfully.");
        }

    }
}
