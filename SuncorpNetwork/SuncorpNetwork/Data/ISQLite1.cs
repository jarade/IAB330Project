using System;
using SQLite;

namespace SuncorpNetwork
{
	public interface ISQLite1{
		SQLiteConnection GetConnection();
	}
}

