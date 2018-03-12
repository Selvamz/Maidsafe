# Maidsafe

1. Login
    Please use any of below credentials to login.
        1. username: fac1
           Password: password1

        2. username: fac2
           Password: password2

        3. username: fac3
           Password: password3

2. Storing credentials:
    Used Xam.Plugins.Settings open source nuget's functionalities to store the login credentials on first time log in. Retrieve back it on next time opening app even after app upgrade.

I have tried to use the Xamarin.Auth to store data as per Xamarin.Forms documentation but it throws null reference exception while loading itself in Android platform alone.

3. Student List:
    By default, 5 Students with their mark detailed are stored in the collection. You can add the students by clicking Add student button. And also edit the existing student details by tapping on an item.