﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TransactionDB
{
    private Dictionary<int, Transaction> transactions;

    public Dictionary<int, Transaction> Transactions
    {
        get
        {
            return transactions;
        }
    }

	public void addTransaction(int id)
	{
        transactions.Add(id, new Transaction(id));
	}

	public Transaction getTransaction(int id)
	{
        return transactions[id];
	}

}

