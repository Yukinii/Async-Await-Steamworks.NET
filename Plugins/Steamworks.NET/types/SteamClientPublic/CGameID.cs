// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct CGameID : System.IEquatable<CGameID>, System.IComparable<CGameID> {
		public ulong _GameID;

		public enum EGameIDType {
			EGameIDTypeApp = 0,
			EGameIDTypeGameMod = 1,
			EGameIDTypeShortcut = 2,
			EGameIDTypeP2P = 3,
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
			SetType(EGameIDType.EGameIDTypeGameMod);
			SetModID(nModID);
		}

		public bool IsSteamApp() => Type() == EGameIDType.EGameIDTypeApp;

	    public bool IsMod() => Type() == EGameIDType.EGameIDTypeGameMod;

	    public bool IsShortcut() => Type() == EGameIDType.EGameIDTypeShortcut;

	    public bool IsP2PFile() => Type() == EGameIDType.EGameIDTypeP2P;

	    public AppId AppID() => new AppId((uint)(_GameID & 0xFFFFFFul));

	    public EGameIDType Type() => (EGameIDType)((_GameID >> 24) & 0xFFul);

	    public uint ModID() => (uint)((_GameID >> 32) & 0xFFFFFFFFul);

	    public bool IsValid() {
			// Each type has it's own invalid fixed point:
			switch (Type()) {
				case EGameIDType.EGameIDTypeApp:
					return AppID() != AppId.Invalid;

				case EGameIDType.EGameIDTypeGameMod:
					return AppID() != AppId.Invalid && (ModID() & 0x80000000) != 0;

				case EGameIDType.EGameIDTypeShortcut:
					return (ModID() & 0x80000000) != 0;

				case EGameIDType.EGameIDTypeP2P:
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
