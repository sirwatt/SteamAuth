﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAuth
{
    public class Confirmation
    {
        /// <summary>
        /// The ID of this confirmation
        /// </summary>
        public ulong ID;

        /// <summary>
        /// The unique nonce used to act upon this confirmation.
        /// </summary>
        public ulong Nonce;

        /// <summary>
        /// The value of the data-type HTML attribute returned for this contribution.
        /// </summary>
        public int IntType;

        /// <summary>
        /// Represents either the Trade Offer ID or market transaction ID that caused this confirmation to be created.
        /// </summary>
        public ulong CreatorID;

        /// <summary>
        /// The type of this confirmation.
        /// </summary>
        public ConfirmationType ConfType;

        /// <summary>
        /// Username of the trade partner
        /// </summary>
        public string Headline;

        /// <summary>
        /// Summary of the trade
        /// </summary>
        public List<string> Summary;

        /// <summary>
        /// Creation time of confirmation
        /// </summary>
        public int CreationTime;

        /// <summary>
        /// Icon of the trade partner
        /// </summary>
        public string Icon;

        public Confirmation(ulong id, ulong nonce, int type, ulong creator_id, string headline, List<string> summary, int creation_time, string icon)
        {
            this.ID = id;
            this.Nonce = nonce;
            this.IntType = type;
            this.CreatorID = creator_id;
            this.Headline = headline;

            //Do a switch simply because we're not 100% certain of all the possible types.
            switch (type)
            {
                case 1:
                    this.ConfType = ConfirmationType.GenericConfirmation;
                    break;
                case 2:
                    this.ConfType = ConfirmationType.Trade;
                    break;
                case 3:
                    this.ConfType = ConfirmationType.MarketSellTransaction;
                    break;
                default:
                    this.ConfType = ConfirmationType.Unknown;
                    break;
            }
        }

        public enum ConfirmationType
        {
            GenericConfirmation,
            Trade,
            MarketSellTransaction,
            Unknown
        }
    }
}
