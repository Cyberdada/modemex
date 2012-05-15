using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise
{


    public class ConnectionImp:Connection   
    {
        
        private ConnectionState _ConnectionState;
        private string userName ;
        private string userpwd ;
        public enum ConnectionState
        {
            Unknown=-1,
            Closed=0,
            Open=1
        }

        private void initialize()
        {
            _ConnectionState = ConnectionState.Unknown;
            Log = new List<string>();

        }

        public ConnectionImp()
        {
            initialize();
        }

        public ConnectionImp(string userName, string password)
        {
            // TODO: Complete member initialization
            initialize();
            this.userName = userName;
            this.userpwd = password;
        }


        public List<string> Log { get; set; }

        public ConnectionState State  {
            get {return _ConnectionState;  }
        }

        public void Open()
        {
            if(_ConnectionState==ConnectionState.Open) throw new ConnectionIsOpenException("Already open");

            _ConnectionState = ConnectionState.Open;
        }



        public void Close()
        {
            _ConnectionState = ConnectionState.Closed;
        }

        public void Login()
        {
            GuardConnectionClosed();
            Log.Add(string.Format("LOGIN {0} {1}", userName, userpwd));
           
        }

        public void Logout()
        {
            GuardConnectionClosed();
            Log.Add(string.Format("LOGOUT {0}", userName));
        }

        private void GuardConnectionClosed()
        {
            if (_ConnectionState == ConnectionState.Closed) throw new ConnectionIsClosedException("Connection is closed");
        }

        public int Status()
        {
            return (int)this.State; 
        }

        public int BytesSent()
        {
            throw new NotImplementedException();
        }

        public void Send(string text)
        {
            throw new NotImplementedException();
        }
    }

public class ConnectionIsOpenException : Exception
{
  public ConnectionIsOpenException() { }
  public ConnectionIsOpenException( string message ) : base( message ) { }
  public ConnectionIsOpenException( string message, Exception inner ) : base( message, inner ) { }
  protected ConnectionIsOpenException( 
	System.Runtime.Serialization.SerializationInfo info, 
	System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
}
public class ConnectionIsClosedException : Exception
{
    public ConnectionIsClosedException() { }
    public ConnectionIsClosedException(string message) : base(message) { }
    public ConnectionIsClosedException(string message, Exception inner) : base(message, inner) { }
    protected ConnectionIsClosedException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}

}
