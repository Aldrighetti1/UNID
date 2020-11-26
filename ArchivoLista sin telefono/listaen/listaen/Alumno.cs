using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace listaen
{
    class Alumno
    {
        List<Alumno> ListaAlumnos = new List<Alumno>();
        string matricula;
        string nombre;
        string apellidoPaterno;
        string apellidoMaterno;
        string direccion;
        string ArchivoAlumno = "Alumno.txt";
        FileStream filestream;
        StreamWriter streamWriter;
        StreamReader streamReader;

        public string Matricula { get => matricula; set => matricula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Direccion { get => direccion; set => direccion = value; }

        public Alumno()
        {
        }
        public Alumno(string matricula, string nombre, string apellidoPaterno, string apellidoMaterno, string direccion)
        {
            this.matricula = matricula;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.direccion = direccion;

        }
        public bool Guardar()
        {
            bool statutus = false;
            filestream = new FileStream(ArchivoAlumno, FileMode.Append, FileAccess.Write);
            streamWriter = new StreamWriter(filestream);
            try {
                streamWriter.WriteLine(matricula+"|"+nombre+"|"+apellidoPaterno+"|"+apellidoMaterno+"|"+direccion);
                statutus = true;
            }
            catch {
                statutus = false;
            }
            streamWriter.Close();
            filestream.Close();
            
            
            return statutus;
        }
        public List<Alumno> LeerArchivo()
        {
            filestream = new FileStream(ArchivoAlumno, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            streamReader = new StreamReader(filestream);
            char delimitador = '|';
            while (!streamReader.EndOfStream)
            {
                string campos = streamReader.ReadLine();
                string[] camposAlumno = campos.Split(delimitador);
                ListaAlumnos.Add(new Alumno{matricula=camposAlumno[0],nombre=camposAlumno[1], apellidoPaterno=camposAlumno[2],
                    apellidoMaterno=camposAlumno[3],direccion=camposAlumno[4]});
            }
            streamReader.Close();
            filestream.Close();
           
            
            return ListaAlumnos;
        }
    }
}
