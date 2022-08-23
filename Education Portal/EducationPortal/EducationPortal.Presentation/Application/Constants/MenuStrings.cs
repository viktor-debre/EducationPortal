namespace EducationPortal.Presentation.Application
{
    internal static class MenuStrings
    {
        public static string AUTH_MENU = "Input command to countinue work:\n" +
            "1 - to authenticate\n" +
            "2 - to register";

        public static string REGISTRATION_MENU = "Registration. Input username and password.\n" +
            "Type quit command to return to authtentication";

        public static string MAIN_MENU = "Type:\n" +
            "1 - to edit materials\n" +
            "2 - to edit skills\n" +
            "3 - to edit courses\n" +
            "4 - logout";

        public static string MATERIAL_MENU = "Editing material menu:\n" +
            "1 - add book,   \t" + "1d  - delete book,   \t" + "1u - update book\n" +
            "2 - add video,  \t" + "2d  - delete video,  \t" + "2u - update video\n" +
            "3 - add article,\t" + "3d  - delete article,\t" + "3u - update article\n" +
            "quit - go to previous menu";

        public static string COURSE_MENU = "Editing course menu:\n" +
            "1 - add course\n" +
            "2 - delete course\n" +
            "3 - update course\n" +
            "quit - go to previous menu";

        public static string COURSE_MATERIAL_MENU = "Input 'add' - add material or " +
            "'del' - to delete material or " +
            "'stop' - to stop modifing";

        public static string COURSE_SKILL_MENU = "Input 'add' - add skill or " +
            "'del' - to delete skill or " +
            "'stop' - to stop modifing";

        public static string SKILL_MENU = "Editing skill menu:\n" +
            "1 - add skill\n" +
            "2 - delete skill\n" +
            "3 - update skill\n" +
            "quit - go to previous menu";
    }
}
