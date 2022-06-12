﻿using Battle_Assistant.Common;
using Battle_Assistant.Helpers;

namespace Battle_Assistant.Models
{
    /// <summary>
    /// The battle model
    /// </summary>
    public class BattleModel : MasterModel
    {
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    NotifyPropertyChanged("Status");
                }
            }
        }

        private string lastAction;
        public string LastAction
        {
            get { return lastAction; }
            set
            {
                if (lastAction != value)
                {
                    lastAction = value;
                    NotifyPropertyChanged("LastAction");
                }
            }
        }

        private string battleFile;
        public string BattleFile
        {
            get { return battleFile; }
            set
            {
                if(battleFile != value)
                {
                    battleFile = value;
                    SetVarsFromGameFile(battleFile);
                    NotifyPropertyChanged("BattleFile");
                }
            }
        }

        private int currentFileNum;
        public int CurrentFileNum
        {
            get { return currentFileNum; }
            set
            {
                if (currentFileNum != value)
                {
                    currentFileNum = value;
                    NotifyPropertyChanged("CurrentFileNum");
                }
            }
        }

        public bool AutoClean { get; set; }

        public GameModel Game { get; set; }

        public OpponentModel Opponent { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BattleModel() : base()
        {
            Name = "";
            CurrentFileNum = 1;
            AutoClean = false;
            Game = null;
            Opponent = null;
            Status = Common.Status.NO_STATUS;
            LastAction = Actions.NO_LAST_ACTION;
        }

        /// <summary>
        /// Sets the name and file number from the battle file
        /// </summary>
        /// <param name="battleFile">The battle file path</param>
        public void SetVarsFromGameFile(string battleFile)
        {
            Name = FileHelper.GetFileDisplayName(battleFile);
            CurrentFileNum = FileHelper.GetFileNumber(battleFile);
        }
    }
}
