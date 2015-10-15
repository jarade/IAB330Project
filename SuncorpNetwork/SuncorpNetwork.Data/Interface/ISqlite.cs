using System;
using SQLite.Net;

namespace SuncorpNetwork.Data
{
	public interface ISqlite{
		SQLiteConnection GetConnection();
	}
}

