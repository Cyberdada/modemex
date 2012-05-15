using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise
{
   interface Connection 
{
    // Opens the connection to the remote server
    // (in exercise: just remember that connection is open)
    //
    // Should fail if called when already opened 
    void Open();

    // Closes the connection to the remote server
    // (in the excercise: just remember you did) 
    void Close();

    // Logs in by sending "LOGIN <USER> <PASSWORD>", where USER and PASSWORD are provided
    // in advance (for instance, as arguments to the concrete class). 
    //
    // Should fail if we're not connected.
    void Login();

    // Logs out from the remote server by sending "LOGOUT <USER>" 
    // Should fail if we're not connected
    void Logout();

    // Returns 1 if connection is open
    // Returns 0 if connections is closed
    // Returns -1 if connection never has been opened
    int Status();

    // Returns the number of bytes sent over the wire. 
    // LOGIN and LOGOUT should be counted as well.
    int BytesSent();

    // Sends text to the other end of the connection
    //
    // Should fail if we're not logged in 
    void Send(String text);
}
}
