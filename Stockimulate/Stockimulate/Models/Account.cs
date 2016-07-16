﻿using Stockimulate.Architecture;

namespace Stockimulate.Models
{
    public class Account
    {

        private readonly string _instrumentSymbol;
        private readonly int _traderId;

        //Lazy load
        private Instrument _instrument;
        internal Instrument Instrument => _instrument ?? (_instrument = DataAccess.SessionInstance.GetInstrument(_instrumentSymbol));

        //Lazy load
        private Trader _trader;
        internal Trader Trader => _trader ?? (_trader = DataAccess.SessionInstance.GetTrader(_traderId));

        internal int Position { get; set; }

        internal Account(string instrumentSymbol, int traderId, int position)
        {
            _instrumentSymbol = instrumentSymbol;
            _traderId = traderId;
            Position = position;
        }

    }
}