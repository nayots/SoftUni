namespace SimpleMvc.Framework
{
    public class MvcContext
    {
        private static MvcContext Instance;

        private MvcContext()
        {
        }

        public static MvcContext Get => Instance == null ? (Instance = new MvcContext()) : Instance;

        public string AssemblyName { get; set; }

        public string ControllerFolder { get; set; }

        public string ControllerSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
    }
}