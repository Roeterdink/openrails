﻿// COPYRIGHT 2009, 2010, 2011, 2012, 2013 by the Open Rails project.
// This code is provided to help you understand what Open Rails does and does
// not do. Suggestions and contributions to improve Open Rails are always
// welcome. Use of the code for any other purpose or distribution of the code
// to anyone else is prohibited without specific written permission from
// admin@openrails.org.

namespace ORTS
{
    public interface EventHandler
    {
        void HandleEvent(Event evt);
    }

    public enum Event
    {
        None,
        BellOff,
        BellOn,
        BlowerChange, // NOTE: Currently not used in Open Rails.
        CompressorOff,
        CompressorOn,
        ControlError,
        Couple,
        CoupleB, // NOTE: Currently not used in Open Rails.
        CoupleC, // NOTE: Currently not used in Open Rails.
        CrossingClosing,
        CrossingOpening,
        CylinderCocksToggle, // NOTE: Currently not used in Open Rails.
        DamperChange, // NOTE: Currently not used in Open Rails.
        Derail1, // NOTE: Currently not used in Open Rails.
        Derail2, // NOTE: Currently not used in Open Rails.
        Derail3, // NOTE: Currently not used in Open Rails.
        DynamicBrakeChange, // NOTE: Currently not used in Open Rails.
        DynamicBrakeIncrease, // NOTE: Currently not used in Open Rails.
        DynamicBrakeOff, // NOTE: Currently not used in Open Rails.
        EngineBrakeChange, // NOTE: Currently not used in Open Rails.
        EngineBrakePressureDecrease,
        EngineBrakePressureIncrease,
        EnginePowerOff, // NOTE: Currently not used in Open Rails.
        EnginePowerOn, // NOTE: Currently not used in Open Rails.
        FireboxDoorChange, // NOTE: Currently not used in Open Rails.
        FireboxDoorClose, // NOTE: Currently not used in Open Rails.
        FuelTowerDown, // NOTE: Currently not used in Open Rails.
        FuelTowerTransferEnd, // NOTE: Currently not used in Open Rails.
        FuelTowerTransferStart, // NOTE: Currently not used in Open Rails.
        FuelTowerUp, // NOTE: Currently not used in Open Rails.
        HornOff,
        HornOn,
        LightSwitchToggle,
        Pantograph1Down,
        Pantograph1Toggle, // NOTE: Currently not used in Open Rails.
        Pantograph1Up,
        Pantograph2Down,
        Pantograph2Up,
        PermissionDenied,
        PermissionGranted,
        PermissionToDepart,
        ReverserChange,
        SanderOff,
        SanderOn,
        SemaphoreArm, // NOTE: Currently not used in Open Rails.
        SteamEjector1Off, // NOTE: Currently not used in Open Rails.
        SteamEjector1On, // NOTE: Currently not used in Open Rails.
        SteamEjector2Off, // NOTE: Currently not used in Open Rails.
        SteamEjector2On, // NOTE: Currently not used in Open Rails.
        SteamHeatChange, // NOTE: Currently not used in Open Rails.
        SteamSafetyValveOff, // NOTE: Currently not used in Open Rails.
        SteamSafetyValveOn, // NOTE: Currently not used in Open Rails.
        ThrottleChange,
        TrainBrakeChange,
        TrainBrakePressureDecrease,
        TrainBrakePressureIncrease,
        Uncouple,
        UncoupleB, // NOTE: Currently not used in Open Rails.
        UncoupleC, // NOTE: Currently not used in Open Rails.
        VigilanceAlarmOff,
        VigilanceAlarmOn,
        VigilanceAlarmReset, // NOTE: Currently not used in Open Rails.
        WaterScoopDown, // NOTE: Currently not used in Open Rails.
        WaterScoopUp, // NOTE: Currently not used in Open Rails.
        WiperOff,
        WiperOn,
        _HeadlightDim,
        _HeadlightOff,
        _HeadlightOn,
        _ResetWheelSlip,
    }

    public static class Events
    {
        public enum Source
        {
            None,
            MSTSCar,
            MSTSCrossing,
            MSTSFuelTower,
            MSTSInGame,
            MSTSSignal,
        }

        // PLEASE DO NOT EDIT THESE FUNCTIONS without references and testing!
        // These numbers are the MSTS sound triggers and must match
        // MSTS/MSTSBin behaviour whenever possible. NEVER return values for
        // non-MSTS events when passed an MSTS Source.

        public static Event From(Source source, int eventID)
        {
            switch (source)
            {
                case Source.MSTSCar:
                    if (Program.Simulator.Settings.MSTSBINSound)
                    {
                        switch (eventID)
                        {
                            // MSTSBin codes (documented at http://mstsbin.uktrainsim.com/)
                            case 23: return Event.EnginePowerOn;
                            case 24: return Event.EnginePowerOff;
                            case 66: return Event.Pantograph2Up;
                            case 67: return Event.Pantograph2Down;
                            default: break;
                        }
                    }
                    switch (eventID)
                    {
                        // Calculated from inspection of existing engine .sms files and extensive testing.
                        // Event 1 is unused in MSTS.
                        case 2: return Event.DynamicBrakeIncrease;
                        case 3: return Event.DynamicBrakeOff;
                        case 4: return Event.SanderOn;
                        case 5: return Event.SanderOff;
                        case 6: return Event.WiperOn;
                        case 7: return Event.WiperOff;
                        case 8: return Event.HornOn;
                        case 9: return Event.HornOff;
                        case 10: return Event.BellOn;
                        case 11: return Event.BellOff;
                        case 12: return Event.CompressorOn;
                        case 13: return Event.CompressorOff;
                        case 14: return Event.TrainBrakePressureIncrease;
                        case 15: return Event.ReverserChange;
                        case 16: return Event.ThrottleChange;
                        case 17: return Event.TrainBrakeChange; // Event 17 only works first time in MSTS.
                        case 18: return Event.EngineBrakeChange; // Event 18 only works first time in MSTS; MSTSBin fixes this.
                        // Event 19 is unused in MSTS.
                        case 20: return Event.DynamicBrakeChange;
                        case 21: return Event.EngineBrakePressureIncrease; // Event 21 is defined in sound files but never used in MSTS.
                        case 22: return Event.EngineBrakePressureDecrease; // Event 22 is defined in sound files but never used in MSTS.
                        // Event 23 is unused in MSTS.
                        // Event 24 is unused in MSTS.
                        // Event 25 is possibly a vigilance reset in MSTS sound files but is never used.
                        // Event 26 is a sander toggle in MSTS sound files but is never used.
                        case 27: return Event.SteamEjector2On;
                        case 28: return Event.SteamEjector2Off;
                        // Event 29 is unused in MSTS.
                        case 30: return Event.SteamEjector1On;
                        case 31: return Event.SteamEjector1Off;
                        case 32: return Event.DamperChange;
                        case 33: return Event.BlowerChange;
                        case 34: return Event.CylinderCocksToggle;
                        // Event 35 is unused in MSTS.
                        case 36: return Event.FireboxDoorChange;
                        case 37: return Event.LightSwitchToggle;
                        case 38: return Event.WaterScoopDown;
                        case 39: return Event.WaterScoopUp;
                        // Event 40 is the firebox door open in MSTS sound files but is never used.
                        case 41: return Event.FireboxDoorClose;
                        case 42: return Event.SteamSafetyValveOn;
                        case 43: return Event.SteamSafetyValveOff;
                        case 44: return Event.SteamHeatChange; // Event 44 only works first time in MSTS.
                        case 45: return Event.Pantograph1Up;
                        case 46: return Event.Pantograph1Down;
                        case 47: return Event.Pantograph1Toggle;
                        case 48: return Event.VigilanceAlarmReset;
                        // Event 49 is unused in MSTS.
                        // Event 50 is unused in MSTS.
                        // Event 51 is an engine brake of some kind in MSTS sound files but is never used.
                        // Event 52 is unused in MSTS.
                        // Event 53 is a train brake normal apply in MSTS sound files but is never used.
                        case 54: return Event.TrainBrakePressureDecrease; // Event 54 is a train brake emergency apply in MSTS sound files but is actually a train brake pressure decrease.
                        // Event 55 is unused in MSTS.
                        case 56: return Event.VigilanceAlarmOn;
                        case 57: return Event.VigilanceAlarmOff; // Event 57 is triggered constantly in MSTS when the vigilance alarm is off.
                        case 58: return Event.Couple;
                        case 59: return Event.CoupleB;
                        case 60: return Event.CoupleC;
                        case 61: return Event.Uncouple;
                        case 62: return Event.UncoupleB;
                        case 63: return Event.UncoupleC;
                        // Event 64 is unused in MSTS.
                        default: return 0;
                    }
                case Source.MSTSCrossing:
                    switch (eventID)
                    {
                        // Calculated from inspection of existing crossing.sms files.
                        case 3: return Event.CrossingClosing;
                        case 4: return Event.CrossingOpening;
                        default: return 0;
                    }
                case Source.MSTSFuelTower:
                    switch (eventID)
                    {
                        // Calculated from inspection of existing *tower.sms files.
                        case 6: return Event.FuelTowerDown;
                        case 7: return Event.FuelTowerUp;
                        case 9: return Event.FuelTowerTransferStart;
                        case 10: return Event.FuelTowerTransferEnd;
                        default: return 0;
                    }
                case Source.MSTSInGame:
                    switch (eventID)
                    {
                        // Calculated from inspection of existing ingame.sms files.
                        case 10: return Event.ControlError;
                        case 20: return Event.Derail1;
                        case 21: return Event.Derail2;
                        case 22: return Event.Derail3;
                        case 25: return 0; // TODO: What is this event?
                        case 60: return Event.PermissionToDepart;
                        case 61: return Event.PermissionGranted;
                        case 62: return Event.PermissionDenied;
                        default: return 0;
                    }
                case Source.MSTSSignal:
                    switch (eventID)
                    {
                        // Calculated from inspection of existing signal.sms files.
                        case 1: return Event.SemaphoreArm;
                        default: return 0;
                    }
                default: return 0;
            }
        }
    }
}
