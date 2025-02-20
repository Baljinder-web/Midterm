# Project Description: Book Management Web

# Installation Guide:
# Follow the steps below to run this project:
1. Go to this link in any browser: [https://github.com/Baljinder-web/Midterm](https://github.com/Baljinder-web/Midterm)
2. Check the top-right corner and look for the button "<> Code".
3. Select this button and go to the last option, "Download ZIP".
4. Click this to download.
5. Go to this folder once the download is complete and extract the contents in "File Explorer".
6. Open this folder in "Visual Studio 2022" or go to the extracted folder and click on "Midterm.sln" to open it directly.
7. Open "Solution Explorer" by going to the "View" option in the menu bar.
8. Delete the "Migrations" folder if it is present.
9. Select "View" from the menu bar of Visual Studio 2022, then go to the "Other Windows" option, and select "Package Manager Console".
10. The "Package Manager Console" will open. Run the command `add-migration Initial`, then run `Update-database`.
11. Under the "Menu Bar", look for the "https" option and click on it.
12. The "Book Web" website will open.
13. You can then register as a user and explore the "Book Management Web".

#  Technologies Used:
1. Visual Studio 2022
2. ASP.NET Core
3. Entity Framework
4. Bootstrap

#  Features:

#  Admin Panel:
1. Admin can add books and members.
2. Admin can edit book details and member details.
3. Admin can view book details for each book.
4. Admin can delete books and members.
5. Admin can assign books to members.
6. Admin can unassign books from members.
7. Admin can update their profile.
8. Admin can see the book list and member list.
9. Admin can search for books by author, title, year, availability, or genre, and filter books.

#  Member Panel:
1. Members can view a list of all books.
2. Members can assign books to themselves.
3. Members can view book details.
4. Members can unassign books from themselves.
5. Members can update their profile.
6. The homepage displays updates, such as newly added books, in the form of slides.
7. Members can search for books by author, title, year, availability, or genre, and filter books.


# Usage Guide:

#  Admin Panel:

1. # Login:
   1. Enter the username and password (*hardcoded, see the code*).
   2. The system will retrieve the details and show the admin homepage.

2. # Add Book:
   1. Select the "New Book" button and enter the required details.
   2. Submit the form.
   3. The system will redirect to the book list to view the recently added book.

3. # Add Member:
   1. Select the "New Member" button and enter the required details.
   2. Optionally, assign a book to the member (if not assigned, it will be marked as "no book issued" and can be assigned later).
   3. Submit the form.
   4.The system will redirect to the member list to view the recently added member.

4. # Edit Book:
   1. Select "Edit or Delete Book".
   2. You will see a book list with options for "Edit" or "Delete".
   3. Use the search and filter options to find a specific book.
   4. Select "Edit", update the details, and save. The system will redirect to the book list to show the updated details.

5. # Delete Book:
   1. Select "Edit or Delete Book".
   2. You will see a book list with options for "Edit" or "Delete".
   3. Select "Delete", and a confirmation page will appear.
   4. Confirm deletion or select "Cancel" to go back.
   5. If deleted, the system will delete the book and redirect to the "Add Book" page.

6. # Book Details:
   1. Select "Edit or Delete Book".
   2. You will see a book list with options for "Edit", "Delete", or "Details".
   3. Select "Details" to view the book details.
   4. The system will show the details and allow you to "Edit" or "Delete" the book.

7. # Edit Member:
   1. Select "Edit or Delete Member".
   2. You will see a member list with options for "Edit" or "Delete".
   3. Select "Edit", update the details, and save.
   4. The system will redirect to the member list to show the updated details.

8. # Delete Member:
   1. Select "Edit or Delete Member".
   2. You will see a member list with options for "Edit" or "Delete".
   3. Select "Delete", and a confirmation page will appear.
   4. Confirm deletion or select "Cancel" to go back.
   5. If deleted, the system will delete the member and redirect to the "Add Member" page.

9. # Assign Book to Members:
   1. Select "Assign Book".
   2. Select the book and the member to assign the book to.
   3. Click "Assign Book" to assign the book.
   4. To cancel, select "Cancel".

10. # Unassign Book from Members:
    1. Select "Unassign Book".
    2. Select the member to unassign the book from.
    3. Click "Unassign Book".
    4. To cancel, select "Cancel".

11. # Update Profile:
    1. Select "Profile" from the navigation bar.
    2. The system will display a form with the current details.
    3. Update the details and click "Update Profile".
    4. A success message will be displayed.

12. # Logout:
    1. Select "Logout" from the navigation bar.

13. # Homepage:
    1. Select "Home" from the navigation bar.



#  Member Panel:

1. # Login:
   1. Enter the username and password.
   2. The system will retrieve the details and show the member homepage.

2. # Register:
   1. Click on the "Register" option on the login page.
   2. Enter the required details.
   3. Click the "Register" button.
   4. The system will show the login page. Log in with the newly created username and password.

3. # View All Books:
   1. Select "Book List" from the navigation bar.
   2. The system will show all books.
   3. Use the search or filter options to find specific books.

4. # Assign Book:
   1. Select "Assign Book" from the navigation bar.
   2. Select the book and your name to assign the book.
   3. Click "Assign Book" to assign the book.
   4. To cancel, select "Cancel".

5. # Unassign Book:
   1. Select "Unassign Book" from the navigation bar.
   2. Select your name to unassign the book.
   3. Click "Unassign Book" to unassign the book.
   4. To cancel, select "Cancel".

6. # Update Profile:
   1. Select "Profile" from the navigation bar.
   2. The system will display a form with the current details.
   3. Update the details and click "Update Profile".
   4. A success message will be displayed.

7. # Logout:
   1. Select "Logout" from the navigation bar.

8. # Homepage:
   1. Select "Home" from the navigation bar.



#   Contact Information:
Email: BaljinderSingh3973@conestogac.on.ca 
