namespace EducationPortal.Presentation.Application
{
    internal class ConsoleMaterialManager
    {
        private readonly IMaterialManageService _materialManageService;

        public ConsoleMaterialManager(IMaterialManageService materialManageService)
        {
            _materialManageService = materialManageService;
        }

        public void EditMaterials()
        {
            Console.Clear();
            Console.WriteLine("Materials:");
            Console.WriteLine("Editing material menu:");

        }

    }
}
