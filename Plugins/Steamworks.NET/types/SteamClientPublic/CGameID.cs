// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct CGameID : System.IEquatable<CGameID>, System.IComparable<CGameID> {
		public ulong _GameID;

		public enum EGameIDType {
			k_EGameIDTypeApp = 0,
			k_EGameIDTypeGameMod = 1,
			k_EGameIDTypeShortcut = 2,
			k_EGameIDTypeP2P = 3,
		};

		public CGameID(ulong GameID) {
			_GameID = GameID;
		}

		public CGameID(AppId appId) {
			_GameID = 0;
			SetAppID(appId);
		}

		public CGameID(AppId appId, uint nModID) {
			_GameID = 0;
			SetAppID(appId);
			SetType(EGameIDType.k_EGameIDTypeGameMod);
			SetModID(nModID);
		}

		public bool IsSteamApp() => Type() == EGameIDType.k_EGameIDTypeApp;

	    public bool IsMod() => Type() == EGameIDType.k_EGameIDTypeGameMod;

	    public bool IsShortcut() => Type() == EGameIDType.k_EGameIDTypeShortcut;

	    public bool IsP2PFile() => Type() == EGameIDType.k_EGameIDTypeP2P;

	    public AppId AppID() => new AppId((uint)(_GameID & 0xFFFFFFul));

	    public EGameIDType Type() => (EGameIDType)((_GameID >> 24) & 0xFFul);

	    public uint ModID() => (uint)((_GameID >> 32) & 0xFFFFFFFFul);

	    public bool IsValid() {
			// Each type has it's own invalid fixed point:
			switch (Type()) {
				case EGameIDType.k_EGameIDTypeApp:
					return AppID() != AppId.Invalid;

				case EGameIDType.k_EGameIDTypeGameMod:
					return AppID() != AppId.Invalid && (ModID() & 0x80000000) != 0;

				case EGameIDType.k_EGameIDTypeShortcut:
					return (ModID() & 0x80000000) != 0;

				case EGameIDType.k_EGameIDTypeP2P:
					return AppID() == AppId.Invalid && (ModID() & 0x80000000) != 0;

				default:
					return false;
			}
		}

		public void Reset() {
			_GameID = 0;
		}

		public void Set(ulong GameID) {
			_GameID = GameID;
		}

		#region Private Setters for internal use
		private void SetAppID(AppId other) {
			_GameID = (_GameID & ~(0xFFFFFFul << 0)) | (((ulong)(other) & 0xFFFFFFul) << 0);
		}

		private void SetType(EGameIDType other) {
			_GameID = (_GameID & ~(0xFFul << 24)) | (((ulong)(other) & 0xFFul) << 24);
		}

		private void SetModID(uint other) {
			_GameID = (_GameID & ~(0xFFFFFFFFul << 32)) | ((other & 0xFFFFFFFFul) << 32);
		}
		#endregion

		#region Overrides
		public override string ToString() => _GameID.ToString();

	    public override bool Equals(object other) => other is CGameID && this == (CGameID)other;

	    public override int GetHashCode() => _GameID.GetHashCode();

	    public static bool operator ==(CGameID x, CGameID y) => x._GameID == y._GameID;

	    public static bool operator !=(CGameID x, CGameID y) => !(x == y);

	    public static explicit operator CGameID(ulong value) => new CGameID(value);

	    public static explicit operator ulong(CGameID that) => that._GameID;

	    public bool Equals(CGameID other) => _GameID == other._GameID;

	    public int CompareTo(CGameID other) => _GameID.CompareTo(other._GameID);

	    #endregion
	}
}
