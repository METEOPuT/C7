using AnimalLibrary;
using System;
using System.Reflection;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        XDocument xmlDoc = new XDocument(
            new XElement("Classes")
        );

        foreach (Type type in assembly.GetTypes())
        {
            if (type.IsClass && (type == typeof(Animal) || type.IsSubclassOf(typeof(Animal))))
            {
                XElement classElement = new XElement("Class",
                    new XAttribute("Name", type.Name)
                );
                var commentAttr = type.GetCustomAttribute<CommentAttribute>();
                if (commentAttr != null)
                {
                    classElement.Add(new XElement("Comment", commentAttr.Comment));
                }

                XElement propertiesElement = new XElement("Properties");
                foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    propertiesElement.Add(new XElement("Property",
                        new XAttribute("Name", prop.Name),
                        new XAttribute("Type", prop.PropertyType.Name)
                    ));
                }
                classElement.Add(propertiesElement);

                XElement methodsElement = new XElement("Methods");
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    if (!method.IsSpecialName)
                    {
                        methodsElement.Add(new XElement("Method",
                            new XAttribute("Name", method.Name),
                            new XAttribute("ReturnType", method.ReturnType.Name)
                        ));
                    }
                }
                classElement.Add(methodsElement);

                xmlDoc.Root.Add(classElement);
            }
        }

        xmlDoc.Save("classes.xml");
        Console.WriteLine("XML файл создан: classes.xml");
    }
}