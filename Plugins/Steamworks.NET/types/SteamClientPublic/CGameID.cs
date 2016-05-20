// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct GameId : System.IEquatable<GameId>, System.IComparable<GameId> {
		public ulong Id;

		public enum GameType {
			App = 0,
			GameMod = 1,
			Shortcut = 2,
			P2P = 3,
		};

		public GameId(ulong id) {
			Id = id;
		}

		public GameId(AppId appId) {
			Id = 0;
			SetAppId(appId);
		}

		public GameId(AppId appId, uint modId) {
			Id = 0;
			SetAppId(appId);
			SetType(GameType.GameMod);
			SetModId(modId);
		}

		public bool IsSteamApp() => Type() == GameType.App;

	    public bool IsMod() => Type() == GameType.GameMod;

	    public bool IsShortcut() => Type() == GameType.Shortcut;

	    public bool IsP2PFile() => Type() == GameType.P2P;

	    public AppId AppId() => new AppId((uint)(Id & 0xFFFFFFul));

	    public GameType Type() => (GameType)((Id >> 24) & 0xFFul);

	    public uint ModId() => (uint)((Id >> 32) & 0xFFFFFFFFul);

	    public bool IsValid() {
			// Each type has it's own invalid fixed point:
			switch (Type()) {
				case GameType.App:
					return AppId() != global::Steamworks.AppId.Invalid;

				case GameType.GameMod:
					return AppId() != global::Steamworks.AppId.Invalid && (ModId() & 0x80000000) != 0;

				case GameType.Shortcut:
					return (ModId() & 0x80000000) != 0;

				case GameType.P2P:
					return AppId() == global::Steamworks.AppId.Invalid && (ModId() & 0x80000000) != 0;

				default:
					return false;
			}
		}

		public void Reset() {
			Id = 0;
		}

		public void Set(ulong gameId) {
			Id = gameId;
		}

		#region Private Setters for internal use
		private void SetAppId(AppId other) {
			Id = (Id & ~(0xFFFFFFul << 0)) | (((ulong)(other) & 0xFFFFFFul) << 0);
		}

		private void SetType(GameType other) {
			Id = (Id & ~(0xFFul << 24)) | (((ulong)(other) & 0xFFul) << 24);
		}

		private void SetModId(uint other) {
			Id = (Id & ~(0xFFFFFFFFul << 32)) | ((other & 0xFFFFFFFFul) << 32);
		}
		#endregion

		#region Overrides
		public override string ToString() => Id.ToString();

	    public override bool Equals(object other) => other is GameId && this == (GameId)other;

	    public override int GetHashCode() => Id.GetHashCode();

	    public static bool operator ==(GameId x, GameId y) => x.Id == y.Id;

	    public static bool operator !=(GameId x, GameId y) => !(x == y);

	    public static explicit operator GameId(ulong value) => new GameId(value);

	    public static explicit operator ulong(GameId that) => that.Id;

	    public bool Equals(GameId other) => Id == other.Id;

	    public int CompareTo(GameId other) => Id.CompareTo(other.Id);

	    #endregion
	}
}
