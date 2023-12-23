![Screenshot (90)](https://github.com/DROBNSON/LocalPass/assets/120675228/e214d6a5-9874-45b4-aac3-05e6ee116b58)


Welcome to Local Pass, a password generator that generates robust passwords through both random characters and custom inputs. Leveraging the entity core framework for CRUD operations, the application creates and securely stores passwords for the current session's user. The inspiration for developing this application arose when faced with the necessity of crafting a robust password for a local machine without an available internet connection.

Sign In Page

Upon initiating the application, users are promptly presented with the sign-in page. The page features fields for username and password inputs, accompanied by a hyperlink leading to the registration page and an exit button for closing the application. Upon entering credentials, correct authentication grants access to the homepage, while incorrect entries prompt an error message.

Registration Page

Users without an existing account on their device can create one through the registration page. The page incorporates three fields for username creation, account password, and password confirmation, along with buttons facilitating a return to the sign-in page and finalizing account creation. Inputting existing or incorrect credentials triggers an error message. If the provided account details meet all requirements, a new account is established, redirecting the user to the homepage upon selecting "create account."

Homepage

Upon successful sign-in, users are immediately directed to the homepage. The interface offers various options, including three vertically centered buttons for the Random Password Page, Custom Password Page, and Past Passwords Page. To manage their account or delete their username, users can access the account icon at the top right corner. Returning to the sign-in page is possible through the bottom-left back button.

Random Password Page:

This page enables the generation of a strong, randomized password by clicking the "Create Password" button. Subsequently, a "Copy to Clipboard" button appears on the right-hand side. Users can return to the previous page by clicking the back button.

Custom Password Page:

This page allows users to create a randomized password using custom inputs. The only mandatory field is the length input; if insufficient data is provided, the app employs random characters to complete the remaining nodes. Functionality mirrors that of the Random Password Page, with the addition of customizable information input.

Past Password Page:

This page displays all passwords associated with the current session's user. Users can filter, select, and delete displayed passwords based on their preferences.

