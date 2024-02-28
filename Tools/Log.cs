namespace Tools
{
    public sealed class Log
    {
        private static Log _instance = null;
        //lo dejamos vacio
        private string _path;

        //creamos un metodo estatico para obtener la instancia e inicializar el path
        public static Log GetInstance(string path)
        {
            //si la instancia es nula la creamos
            if (_instance == null)
            {
                _instance = new Log(path);
                _instance._path = path;
            }
            return _instance;
        }
        //recibe el path que creamos en el metodo anterior
        private Log(string path)
        {
            _path = path;
        }
        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
