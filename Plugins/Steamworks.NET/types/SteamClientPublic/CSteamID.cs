// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamId : System.IEquatable<SteamId>, System.IComparable<SteamId> {
		public static readonly SteamId Nil = new SteamId();
		public static readonly SteamId OutofDate = new SteamId(new AccountId(0), 0, EUniverse.Invalid, EAccountType.Invalid);
		public static readonly SteamId LanMode = new SteamId(new AccountId(0), 0, EUniverse.Public, EAccountType.Invalid);
		public static readonly SteamId NotInitYet = new SteamId(new AccountId(1), 0, EUniverse.Invalid, EAccountType.Invalid);
		public static readonly SteamId NonSteam = new SteamId(new AccountId(2), 0, EUniverse.Invalid, EAccountType.Invalid);
		public ulong Id;

		public SteamId(AccountId accountId, EUniverse eUniverse, EAccountType eAccountType) {
			Id = 0;
			Set(accountId, eUniverse, eAccountType);
		}

		public SteamId(AccountId accountId, uint unAccountInstance, EUniverse eUniverse, EAccountType eAccountType) {
			Id = 0;
#if _SERVER && Assert
		Assert( ! ( ( EAccountType.Individual == eAccountType ) && ( unAccountInstance > SteamUserWebInstance ) ) );	// enforce that for individual accounts, instance is always 1
#endif // _SERVER
			InstancedSet(accountId, unAccountInstance, eUniverse, eAccountType);
		}

		public SteamId(ulong ulId) {
			Id = ulId;
		}

		public void Set(AccountId accountId, EUniverse eUniverse, EAccountType eAccountType) {
			SetAccountId(accountId);
			SetEUniverse(eUniverse);
			SetEAccountType(eAccountType);

			if (eAccountType == EAccountType.Clan || eAccountType == EAccountType.GameServer) {
				SetAccountInstance(0);
			}
			else {
				// by default we pick the desktop instance
				SetAccountInstance(Constants.SteamUserDesktopInstance);
			}
		}

		public void InstancedSet(AccountId accountId, uint unInstance, EUniverse eUniverse, EAccountType eAccountType) {
			SetAccountId(accountId);
			SetEUniverse(eUniverse);
			SetEAccountType(eAccountType);
			SetAccountInstance(unInstance);
		}

		public void Clear() {
			Id = 0;
		}

		public void CreateBlankAnonLogon(EUniverse eUniverse) {
			SetAccountId(new AccountId(0));
			SetEUniverse(eUniverse);
			SetEAccountType(EAccountType.AnonGameServer);
			SetAccountInstance(0);
		}

		public void CreateBlankAnonUserLogon(EUniverse eUniverse) {
			SetAccountId(new AccountId(0));
			SetEUniverse(eUniverse);
			SetEAccountType(EAccountType.AnonUser);
			SetAccountInstance(0);
		}

		//-----------------------------------------------------------------------------
		// Purpose: Is this an anonymous game server login that will be filled in?
		//-----------------------------------------------------------------------------
		public bool BBlankAnonAccount() => GetAccountId() == new AccountId(0) && BAnonAccount() && GetUnAccountInstance() == 0;

	    //-----------------------------------------------------------------------------
		// Purpose: Is this a game server account id?  (Either persistent or anonymous)
		//-----------------------------------------------------------------------------
		public bool BGameServerAccount() => GetEAccountType() == EAccountType.GameServer || GetEAccountType() == EAccountType.AnonGameServer;

	    //-----------------------------------------------------------------------------
		// Purpose: Is this a persistent (not anonymous) game server account id?
		//-----------------------------------------------------------------------------
		public bool BPersistentGameServerAccount() => GetEAccountType() == EAccountType.GameServer;

	    //-----------------------------------------------------------------------------
		// Purpose: Is this an anonymous game server account id?
		//-----------------------------------------------------------------------------
		public bool BAnonGameServerAccount() => GetEAccountType() == EAccountType.AnonGameServer;

	    //-----------------------------------------------------------------------------
		// Purpose: Is this a content server account id?
		//-----------------------------------------------------------------------------
		public bool BContentServerAccount() => GetEAccountType() == EAccountType.ContentServer;


	    //-----------------------------------------------------------------------------
		// Purpose: Is this a clan account id?
		//-----------------------------------------------------------------------------
		public bool BClanAccount() => GetEAccountType() == EAccountType.Clan;


	    //-----------------------------------------------------------------------------
		// Purpose: Is this a chat account id?
		//-----------------------------------------------------------------------------
		public bool BChatAccount() => GetEAccountType() == EAccountType.Chat;

	    //-----------------------------------------------------------------------------
		// Purpose: Is this a chat account id?
		//-----------------------------------------------------------------------------
		public bool IsLobby() => (GetEAccountType() == EAccountType.Chat)
		                         && (GetUnAccountInstance() & (int)EChatSteamIdInstanceFlags.Lobby) != 0;


	    //-----------------------------------------------------------------------------
		// Purpose: Is this an individual user account id?
		//-----------------------------------------------------------------------------
		public bool BIndividualAccount() => GetEAccountType() == EAccountType.Individual || GetEAccountType() == EAccountType.ConsoleUser;


	    //-----------------------------------------------------------------------------
		// Purpose: Is this an anonymous account?
		//-----------------------------------------------------------------------------
		public bool BAnonAccount() => GetEAccountType() == EAccountType.AnonUser || GetEAccountType() == EAccountType.AnonGameServer;

	    //-----------------------------------------------------------------------------
		// Purpose: Is this an anonymous user account? ( used to create an account or reset a password )
		//-----------------------------------------------------------------------------
		public bool BAnonUserAccount() => GetEAccountType() == EAccountType.AnonUser;

	    //-----------------------------------------------------------------------------
		// Purpose: Is this a faked up Steam ID for a PSN friend account?
		//-----------------------------------------------------------------------------
		public bool BConsoleUserAccount() => GetEAccountType() == EAccountType.ConsoleUser;

	    public void SetAccountId(AccountId other) {
			Id = (Id & ~(0xFFFFFFFFul << 0)) | (((ulong)(other) & 0xFFFFFFFFul) << 0);
		}

		public void SetAccountInstance(uint other) {
			Id = (Id & ~(0xFFFFFul << 32)) | ((other & 0xFFFFFul) << 32);
		}

		// This is a non standard/custom function not found in C++ Steamworks
		public void SetEAccountType(EAccountType other) {
			Id = (Id & ~(0xFul << 52)) | (((ulong)(other) & 0xFul) << 52);
		}

		public void SetEUniverse(EUniverse other) {
			Id = (Id & ~(0xFFul << 56)) | (((ulong)(other) & 0xFFul) << 56);
		}

		public void ClearIndividualInstance() {
			if (BIndividualAccount())
				SetAccountInstance(0);
		}

		public bool HasNoIndividualInstance() => BIndividualAccount() && (GetUnAccountInstance() == 0);

	    public AccountId GetAccountId() => new AccountId((uint)(Id & 0xFFFFFFFFul));

	    public uint GetUnAccountInstance() => (uint)((Id >> 32) & 0xFFFFFul);

	    public EAccountType GetEAccountType() => (EAccountType)((Id >> 52) & 0xFul);

	    public EUniverse GetEUniverse() => (EUniverse)((Id >> 56) & 0xFFul);

	    public bool IsValid() {
			if (GetEAccountType() <= EAccountType.Invalid || GetEAccountType() >= EAccountType.Max)
				return false;

			if (GetEUniverse() <= EUniverse.Invalid || GetEUniverse() >= EUniverse.Max)
				return false;

			if (GetEAccountType() == EAccountType.Individual) {
				if (GetAccountId() == new AccountId(0) || GetUnAccountInstance() > Constants.SteamUserWebInstance)
					return false;
			}

			if (GetEAccountType() == EAccountType.Clan) {
				if (GetAccountId() == new AccountId(0) || GetUnAccountInstance() != 0)
					return false;
			}

	        if (GetEAccountType() != EAccountType.GameServer) return true;
	        return GetAccountId() != new AccountId(0);
	        // Any limit on instances?  We use them for local users and bots
	    }

		#region Overrides
		public override string ToString() => Id.ToString();

	    public override bool Equals(object other) => other is SteamId && this == (SteamId)other;

	    public override int GetHashCode() => Id.GetHashCode();

	    public static bool operator ==(SteamId x, SteamId y) => x.Id == y.Id;

	    public static bool operator !=(SteamId x, SteamId y) => !(x == y);

	    public static explicit operator SteamId(ulong value) => new SteamId(value);
	    public static explicit operator ulong(SteamId that) => that.Id;

	    public bool Equals(SteamId other) => Id == other.Id;

	    public int CompareTo(SteamId other) => Id.CompareTo(other.Id);

	    #endregion
	}
}
