
using System;
using zkemkeeper;

namespace BioMetrixCore
{
    public class ZkemClient : IZKEM
    {
        Action<object, string> RaiseDeviceEvent;

        public ZkemClient(Action<object, string> RaiseDeviceEvent)
        { this.RaiseDeviceEvent = RaiseDeviceEvent; }


        internal CZKEM objCZKEM = new CZKEM();

        #region 'What we will be using'

        public bool BatchUpdate(int dwMachineNumber)
        {
            return objCZKEM.BatchUpdate(dwMachineNumber);
        }

        public bool Beep(int DelayMS)
        {
            return objCZKEM.Beep(DelayMS);
        }

        public bool BeginBatchUpdate(int dwMachineNumber, int UpdateFlag)
        {
            return objCZKEM.BeginBatchUpdate(dwMachineNumber, UpdateFlag);
        }


        public bool ClearData(int dwMachineNumber, int DataFlag)
        {
            return objCZKEM.ClearData(dwMachineNumber, DataFlag);
        }


        public bool ClearGLog(int dwMachineNumber)
        {
            return objCZKEM.ClearGLog(dwMachineNumber);
        }


        public bool Connect_Net(string IPAdd, int Port)
        {
            if (objCZKEM.Connect_Net(IPAdd, Port))
            {
                //65535, 32767
                if (objCZKEM.RegEvent(1, 32767))
                {
                    // [ Register your events here ]
                    // [ Go through the _IZKEMEvents_Event class for a complete list of events
                    objCZKEM.OnConnected += ObjCZKEM_OnConnected;
                    objCZKEM.OnDisConnected += objCZKEM_OnDisConnected;
                    objCZKEM.OnEnrollFinger += ObjCZKEM_OnEnrollFinger;
                    objCZKEM.OnFinger += ObjCZKEM_OnFinger;
                    objCZKEM.OnAttTransactionEx += new _IZKEMEvents_OnAttTransactionExEventHandler(zkemClient_OnAttTransactionEx);
                }
                return true;
            }
            return false;
        }

        private void ObjCZKEM_OnFinger()
        {
        }

        private void ObjCZKEM_OnEnrollFinger(int EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        { }

        private void ObjCZKEM_OnConnected()
        {
        }

        private void zkemClient_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        { }

        void objCZKEM_OnDisConnected()
        {
            RaiseDeviceEvent(this, UniversalStatic.acx_Disconnect);
        }


        public bool DelUserTmp(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex)
        {
            return DelUserTmp(dwMachineNumber, dwEnrollNumber, dwFingerIndex);
        }

        public bool DisableDeviceWithTimeOut(int dwMachineNumber, int TimeOutSec)
        {
            return objCZKEM.DisableDeviceWithTimeOut(dwMachineNumber, TimeOutSec);
        }


        public bool EnableDevice(int dwMachineNumber, bool bFlag)
        {
            return objCZKEM.EnableDevice(dwMachineNumber, bFlag);
        }


        public bool GetDeviceTime(int dwMachineNumber, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute, ref int dwSecond)
        {
            return objCZKEM.GetDeviceTime(dwMachineNumber, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond);
        }


        public bool GetUserInfo(int dwMachineNumber, int dwEnrollNumber, ref string Name, ref string Password, ref int Privilege, ref bool Enabled)
        {
            return GetUserInfo(dwMachineNumber, dwEnrollNumber, ref Name, ref Password, ref Privilege, ref Enabled);
        }


        public bool GetUserInfoEx(int dwMachineNumber, int dwEnrollNumber, out int VerifyStyle, out byte Reserved)
        {
            return objCZKEM.GetUserInfoEx(dwMachineNumber, dwEnrollNumber, out VerifyStyle, out Reserved);
        }

        public bool GetUserTmp(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex, ref byte TmpData, ref int TmpLength)
        {
            return objCZKEM.GetUserTmp(dwMachineNumber, dwEnrollNumber, dwFingerIndex, ref TmpData, ref TmpLength);
        }

        public bool GetUserTmpEx(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, out int Flag, out byte TmpData, out int TmpLength)
        {
            return objCZKEM.GetUserTmpEx(dwMachineNumber, dwEnrollNumber, dwFingerIndex, out Flag, out TmpData, out TmpLength);
        }

        public bool GetUserTmpExStr(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, out int Flag, out string TmpData, out int TmpLength)
        {
            return objCZKEM.GetUserTmpExStr(dwMachineNumber, dwEnrollNumber, dwFingerIndex, out Flag, out TmpData, out TmpLength);
        }



        public bool PowerOffDevice(int dwMachineNumber)
        {
            return objCZKEM.PowerOffDevice(dwMachineNumber);
        }


        public bool QueryState(ref int State)
        {
            return objCZKEM.QueryState(ref State);
        }

        public bool ReadAllGLogData(int dwMachineNumber)
        {
            return objCZKEM.ReadAllGLogData(dwMachineNumber);
        }


        public bool ReadAllTemplate(int dwMachineNumber)
        {
            return objCZKEM.ReadAllTemplate(dwMachineNumber);
        }

        public bool ReadAllUserID(int dwMachineNumber)
        {
            return objCZKEM.ReadAllUserID(dwMachineNumber);
        }

        public bool RefreshData(int dwMachineNumber)
        {
            return objCZKEM.RefreshData(dwMachineNumber);
        }

        public bool RegEvent(int dwMachineNumber, int EventMask)
        {
            return objCZKEM.RegEvent(dwMachineNumber, EventMask);
        }

        public bool RestartDevice(int dwMachineNumber)
        {
            return objCZKEM.RestartDevice(dwMachineNumber);
        }


        public bool SaveTheDataToFile(int dwMachineNumber, string TheFilePath, int FileFlag)
        {
            return objCZKEM.SaveTheDataToFile(dwMachineNumber, TheFilePath, FileFlag);
        }


        public bool SetUserTmpExStr(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, int Flag, string TmpData)
        {
            return objCZKEM.SetUserTmpExStr(dwMachineNumber, dwEnrollNumber, dwFingerIndex, Flag, TmpData);
        }

        public bool SSR_EnableUser(int dwMachineNumber, string dwEnrollNumber, bool bFlag)
        {
            return objCZKEM.SSR_EnableUser(dwMachineNumber, dwEnrollNumber, bFlag);
        }

        public bool SSR_GetAllUserInfo(int dwMachineNumber, out string dwEnrollNumber, out string Name, out string Password, out int Privilege, out bool Enabled)
        {
            return objCZKEM.SSR_GetAllUserInfo(dwMachineNumber, out dwEnrollNumber, out Name, out Password, out Privilege, out Enabled);
        }
        public bool GetAllGLogData(int dwMachineNumber, ref int dwTMachineNumber, ref int dwEnrollNumber, ref int dwEMachineNumber, ref int dwVerifyMode, ref int dwInOutMode, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute)
        {
            throw new NotImplementedException();
        }

        public bool GetAllSLogData(int dwMachineNumber, ref int dwTMachineNumber, ref int dwSEnrollNumber, ref int Params4, ref int Params1, ref int Params2, ref int dwManipulation, ref int Params3, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute)
        {
            throw new NotImplementedException();
        }

        public bool GetAllUserInfo(int dwMachineNumber, ref int dwEnrollNumber, ref string Name, ref string Password, ref int Privilege, ref bool Enabled)
        {
            throw new NotImplementedException();
        }


        public bool SSR_GetGeneralLogData(int dwMachineNumber, out string dwEnrollNumber, out int dwVerifyMode, out int dwInOutMode, out int dwYear, out int dwMonth, out int dwDay, out int dwHour, out int dwMinute, out int dwSecond, ref int dwWorkCode)
        {
            return objCZKEM.SSR_GetGeneralLogData(dwMachineNumber, out dwEnrollNumber, out dwVerifyMode, out dwInOutMode, out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkCode);
        }

        public bool SSR_GetUserInfo(int dwMachineNumber, string dwEnrollNumber, out string Name, out string Password, out int Privilege, out bool Enabled)
        {
            return objCZKEM.SSR_GetUserInfo(dwMachineNumber, dwEnrollNumber, out Name, out Password, out Privilege, out Enabled);
        }

        public bool SSR_GetUserTmpStr(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, out string TmpData, out int TmpLength)
        {
            return objCZKEM.SSR_GetUserTmpStr(dwMachineNumber, dwEnrollNumber, dwFingerIndex, out TmpData, out TmpLength);
        }

        public bool SSR_SetUserInfo(int dwMachineNumber, string dwEnrollNumber, string Name, string Password, int Privilege, bool Enabled)
        {
            return objCZKEM.SSR_SetUserInfo(dwMachineNumber, dwEnrollNumber, Name, Password, Privilege, Enabled);
        }

        public bool StartEnroll(int UserID, int FingerID)
        {
            return StartEnroll(UserID, FingerID);
        }

        public bool StartEnrollEx(string UserID, int FingerID, int Flag)
        {
            return StartEnrollEx(UserID, FingerID, Flag);
        }

        public bool StartIdentify()
        { return StartIdentify(); }

        public void Disconnect()
        {
            // [ Unregister events
            objCZKEM.OnConnected -= ObjCZKEM_OnConnected;
            objCZKEM.OnDisConnected -= objCZKEM_OnDisConnected;
            objCZKEM.OnEnrollFinger -= ObjCZKEM_OnEnrollFinger;
            objCZKEM.OnFinger -= ObjCZKEM_OnFinger;
            objCZKEM.OnAttTransactionEx -= new _IZKEMEvents_OnAttTransactionExEventHandler(zkemClient_OnAttTransactionEx);

            objCZKEM.Disconnect();
        }


        public bool GetAllUserID(int dwMachineNumber, ref int dwEnrollNumber, ref int dwEMachineNumber, ref int dwBackupNumber, ref int dwMachinePrivilege, ref int dwEnable)
        { return objCZKEM.GetAllUserID(dwMachineNumber, dwEnrollNumber, dwEMachineNumber, dwBackupNumber, dwMachinePrivilege, dwEnable); }

        public bool GetFirmwareVersion(int dwMachineNumber, ref string strVersion)
        { return objCZKEM.GetFirmwareVersion(dwMachineNumber, strVersion); }

        public bool GetVendor(ref string strVendor)
        { return objCZKEM.GetVendor(strVendor); }

        public bool GetWiegandFmt(int dwMachineNumber, ref string sWiegandFmt)
        { return objCZKEM.GetWiegandFmt(dwMachineNumber, sWiegandFmt); }
        public bool GetSDKVersion(ref string strVersion)
        { return objCZKEM.GetSDKVersion(strVersion); }

        public bool GetSerialNumber(int dwMachineNumber, out string dwSerialNumber)
        { return objCZKEM.GetSerialNumber(dwMachineNumber, out dwSerialNumber); }

        public bool GetDeviceMAC(int dwMachineNumber, ref string sMAC)
        { return objCZKEM.GetDeviceMAC(dwMachineNumber, sMAC); }

        public void GetLastError(ref int dwErrorCode)
        {
            objCZKEM.GetLastError(dwErrorCode);
        }
        #endregion


        #region 'Not Implemented'

        public bool ClearDataEx(int dwMachineNumber, string TableName)
        {
            throw new NotImplementedException();
        }
        public bool GetUserInfoByCard(int dwMachineNumber, ref string Name, ref string Password, ref int Privilege, ref bool Enabled)
        {
            throw new NotImplementedException();
        }

        public bool GetUserInfoByPIN2(int dwMachineNumber, ref string Name, ref string Password, ref int Privilege, ref bool Enabled)
        {
            throw new NotImplementedException();
        }


        public bool CancelBatchUpdate(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool CancelOperation()
        {
            throw new NotImplementedException();
        }

        public bool CaptureImage(bool FullImage, ref int Width, ref int Height, ref byte Image, string ImageFile)
        {
            throw new NotImplementedException();
        }

        public bool ClearAdministrators(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }


        public bool ClearKeeperData(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool ClearLCD()
        {
            throw new NotImplementedException();
        }

        public bool ClearPhotoByTime(int dwMachineNumber, int iFlag, string sTime, string eTime)
        {
            throw new NotImplementedException();
        }

        public bool ClearSLog(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool ClearSMS(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool ClearUserSMS(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool Connect_USB(int MachineNumber)
        {
            throw new NotImplementedException();
        }

        public void ConvertPassword(int dwSrcPSW, ref int dwDestPSW, int dwLength)
        {
            throw new NotImplementedException();
        }

        public bool DelCustomizeAttState(int dwMachineNumber, int StateID)
        {
            throw new NotImplementedException();
        }

        public bool DelCustomizeVoice(int dwMachineNumber, int VoiceID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEnrollData(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSMS(int dwMachineNumber, int ID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserInfoEx(int dwMachineNumber, int dwEnrollNumber)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserSMS(int dwMachineNumber, int dwEnrollNumber, int SMSID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteWorkCode(int WorkCodeID)
        {
            throw new NotImplementedException();
        }

        public bool DelUserFace(int dwMachineNumber, string dwEnrollNumber, int dwFaceIndex)
        {
            throw new NotImplementedException();
        }


        public bool EmptyCard(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool EnableClock(int Enabled)
        {
            throw new NotImplementedException();
        }

        public bool EnableCustomizeAttState(int dwMachineNumber, int StateID, int Enable)
        {
            throw new NotImplementedException();
        }

        public bool EnableCustomizeVoice(int dwMachineNumber, int VoiceID, int Enable)
        {
            throw new NotImplementedException();
        }


        public bool EnableUser(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, bool bFlag)
        {
            throw new NotImplementedException();
        }

        public bool FPTempConvert(ref byte TmpData1, ref byte TmpData2, ref int Size)
        {
            throw new NotImplementedException();
        }
        public bool GetDoorState(int MachineNumber, ref int State)
        {
            throw new NotImplementedException();
        }

        public bool GetEnrollData(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, ref int dwMachinePrivilege, ref int dwEnrollData, ref int dwPassWord)
        {
            throw new NotImplementedException();
        }

        public bool GetEnrollDataStr(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, ref int dwMachinePrivilege, ref string dwEnrollData, ref int dwPassWord)
        {
            throw new NotImplementedException();
        }

        public bool ReadAllSLogData(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool GetUserTmpStr(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex, ref string TmpData, ref int TmpLength)
        {
            throw new NotImplementedException();
        }

        public bool GetUserTZs(int dwMachineNumber, int dwEnrollNumber, ref int TZs)
        {
            throw new NotImplementedException();
        }

        public bool GetUserTZStr(int dwMachineNumber, int dwEnrollNumber, ref string TZs)
        {
            throw new NotImplementedException();
        }



        public bool PlayVoice(int Position, int Length)
        {
            return objCZKEM.PlayVoice(Position, Length);
        }


        public bool GetWorkCode(int WorkCodeID, out int AWorkCode)
        {
            throw new NotImplementedException();
        }

        public int get_AccTimeZones(int Index)
        {
            throw new NotImplementedException();
        }

        public int get_CardNumber(int Index)
        {
            throw new NotImplementedException();
        }

        public string get_STR_CardNumber(int Index)
        {
            throw new NotImplementedException();
        }

        public void Implementor()
        {
        }

        public bool IsTFTMachine(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool MergeTemplate(IntPtr Templates, int FingerCount, ref byte TemplateDest, ref int FingerSize)
        {
            throw new NotImplementedException();
        }

        public bool ModifyPrivilege(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, int dwMachinePrivilege)
        {
            throw new NotImplementedException();
        }



        public bool PlayVoiceByIndex(int Index)
        {
            throw new NotImplementedException();
        }

        public void PowerOnAllDevice()
        {
            throw new NotImplementedException();
        }


        public int GetFPTempLength(ref byte dwEnrollData)
        {
            throw new NotImplementedException();
        }

        public int GetFPTempLengthStr(string dwEnrollData)
        {
            throw new NotImplementedException();
        }

        public bool GetGeneralExtLogData(int dwMachineNumber, ref int dwEnrollNumber, ref int dwVerifyMode, ref int dwInOutMode, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute, ref int dwSecond, ref int dwWorkCode, ref int dwReserved)
        {
            throw new NotImplementedException();
        }

        public bool GetGeneralLogData(int dwMachineNumber, ref int dwTMachineNumber, ref int dwEnrollNumber, ref int dwEMachineNumber, ref int dwVerifyMode, ref int dwInOutMode, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute)
        {
            throw new NotImplementedException();
        }

        public bool GetGeneralLogDataStr(int dwMachineNumber, ref int dwEnrollNumber, ref int dwVerifyMode, ref int dwInOutMode, ref string TimeStr)
        {
            throw new NotImplementedException();
        }

        public bool GetGroupTZs(int dwMachineNumber, int GroupIndex, ref int TZs)
        {
            throw new NotImplementedException();
        }

        public bool GetGroupTZStr(int dwMachineNumber, int GroupIndex, ref string TZs)
        {
            throw new NotImplementedException();
        }

        public bool GetHIDEventCardNumAsStr(out string strHIDEventCardNum)
        {
            throw new NotImplementedException();
        }

        public bool GetHoliday(int dwMachineNumber, ref string Holiday)
        {
            throw new NotImplementedException();
        }

    

        public bool GetPhotoByName(int dwMachineNumber, string PhotoName, out byte PhotoData, out int PhotoLength)
        {
            throw new NotImplementedException();
        }

        public bool GetPhotoCount(int dwMachineNumber, out int count, int iFlag)
        {
            throw new NotImplementedException();
        }

        public bool GetPhotoNamesByTime(int dwMachineNumber, int iFlag, string sTime, string eTime, out string AllPhotoName)
        {
            throw new NotImplementedException();
        }

        public bool GetPIN2(int UserID, ref int PIN2)
        {
            throw new NotImplementedException();
        }

        public bool GetPlatform(int dwMachineNumber, ref string Platform)
        {
            throw new NotImplementedException();
        }

        public bool GetProductCode(int dwMachineNumber, out string lpszProductCode)
        {
            throw new NotImplementedException();
        }

        public bool GetRTLog(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }


        public bool GetSensorSN(int dwMachineNumber, ref string SensorSN)
        {
            throw new NotImplementedException();
        }



        public bool GetSMS(int dwMachineNumber, int ID, ref int Tag, ref int ValidMinutes, ref string StartTime, ref string Content)
        {
            throw new NotImplementedException();
        }

        public bool GetStrCardNumber(out string ACardNumber)
        {
            throw new NotImplementedException();
        }

        public bool GetSuperLogData(int dwMachineNumber, ref int dwTMachineNumber, ref int dwSEnrollNumber, ref int Params4, ref int Params1, ref int Params2, ref int dwManipulation, ref int Params3, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute)
        {
            throw new NotImplementedException();
        }

        public bool GetSuperLogData2(int dwMachineNumber, ref int dwTMachineNumber, ref int dwSEnrollNumber, ref int Params4, ref int Params1, ref int Params2, ref int dwManipulation, ref int Params3, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute, ref int dwSecs)
        {
            throw new NotImplementedException();
        }

        public bool GetSuperLogDataEx(int dwMachineNumber, ref string EnrollNumber, ref int Params4, ref int Params1, ref int Params2, ref int dwManipulation, ref int Params3, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute, ref int dwSecond)
        {
            throw new NotImplementedException();
        }

        public bool GetSysOption(int dwMachineNumber, string Option, out string Value)
        {
            throw new NotImplementedException();
        }

        public bool GetTZInfo(int dwMachineNumber, int TZIndex, ref string TZ)
        {
            throw new NotImplementedException();
        }

        public bool GetUnlockGroups(int dwMachineNumber, ref string Grps)
        {
            throw new NotImplementedException();
        }

        public bool GetUserFace(int dwMachineNumber, string dwEnrollNumber, int dwFaceIndex, ref byte TmpData, ref int TmpLength)
        {
            throw new NotImplementedException();
        }

        public bool GetUserFaceStr(int dwMachineNumber, string dwEnrollNumber, int dwFaceIndex, ref string TmpData, ref int TmpLength)
        {
            throw new NotImplementedException();
        }

        public bool GetUserGroup(int dwMachineNumber, int dwEnrollNumber, ref int UserGrp)
        {
            throw new NotImplementedException();
        }

        public bool GetUserIDByPIN2(int PIN2, ref int UserID)
        {
            throw new NotImplementedException();
        }

        public bool FPTempConvertNew(ref byte TmpData1, ref byte TmpData2, ref int Size)
        {
            throw new NotImplementedException();
        }

        public bool FPTempConvertNewStr(string TmpData1, ref string TmpData2, ref int Size)
        {
            throw new NotImplementedException();
        }

        public bool FPTempConvertStr(string TmpData1, ref string TmpData2, ref int Size)
        {
            throw new NotImplementedException();
        }

        public bool GetACFun(ref int ACFun)
        {
            throw new NotImplementedException();
        }

    
        public int GetBackupNumber(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool GetCardFun(int dwMachineNumber, ref int CardFun)
        {
            throw new NotImplementedException();
        }

        public bool GetDataFile(int dwMachineNumber, int DataFlag, string FileName)
        {
            throw new NotImplementedException();
        }

        public bool GetDataFileEx(int dwMachineNumber, string SourceFileName, string DestFileName)
        {
            throw new NotImplementedException();
        }

        public bool GetDaylight(int dwMachineNumber, ref int Support, ref string BeginTime, ref string EndTime)
        {
            throw new NotImplementedException();
        }

        public bool GetDeviceInfo(int dwMachineNumber, int dwInfo, ref int dwValue)
        {
            throw new NotImplementedException();
        }

        public bool GetDeviceIP(int dwMachineNumber, ref string IPAddr)
        {
            throw new NotImplementedException();
        }


        public bool GetDeviceStatus(int dwMachineNumber, int dwStatus, ref int dwValue)
        {
            throw new NotImplementedException();
        }

        public bool GetDeviceStrInfo(int dwMachineNumber, int dwInfo, out string Value)
        {
            throw new NotImplementedException();
        }



        public bool ClearWorkCode()
        {
            throw new NotImplementedException();
        }

        public bool Connect_Com(int ComPort, int MachineNumber, int BaudRate)
        {
            throw new NotImplementedException();
        }

        public bool Connect_Modem(int ComPort, int MachineNumber, int BaudRate, string Telephone)
        {
            throw new NotImplementedException();
        }


        public int AccGroup
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int BASE64
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int CommPort
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int ConvertBIG5
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int MachineNumber
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public uint PIN2
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int PINWidth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int PullMode
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool ReadMark
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int SSRPin
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool ACUnlock(int dwMachineNumber, int Delay)
        {
            throw new NotImplementedException();
        }

        public bool BackupData(string DataFile)
        {
            throw new NotImplementedException();
        }

        public bool ReadAOptions(string AOption, out string AValue)
        {
            throw new NotImplementedException();
        }

        public bool ReadAttRule(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool ReadCustData(int dwMachineNumber, ref string CustData)
        {
            throw new NotImplementedException();
        }

        public bool ReadDPTInfo(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool ReadFile(int dwMachineNumber, string FileName, string FilePath)
        {
            throw new NotImplementedException();
        }

        public bool ReadGeneralLogData(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool ReadLastestLogData(int dwMachineNumber, int NewLog, int dwYear, int dwMonth, int dwDay, int dwHour, int dwMinute, int dwSecond)
        {
            throw new NotImplementedException();
        }

        public bool ReadRTLog(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool ReadSuperLogData(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool ReadSuperLogDataEx(int dwMachineNumber, int dwYear_S, int dwMonth_S, int dwDay_S, int dwHour_S, int dwMinute_S, int dwSecond_S, int dwYear_E, int dwMonth_E, int dwDay_E, int dwHour_E, int dwMinute_E, int dwSecond_E, int dwLogIndex)
        {
            throw new NotImplementedException();
        }

        public bool ReadTurnInfo(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool ReadUserAllTemplate(int dwMachineNumber, string dwEnrollNumber)
        {
            throw new NotImplementedException();
        }


        public bool RestoreData(string DataFile)
        {
            throw new NotImplementedException();
        }


        public bool SendCMDMsg(int dwMachineNumber, int Param1, int Param2)
        {
            throw new NotImplementedException();
        }

        public bool SendFile(int dwMachineNumber, string FileName)
        {
            throw new NotImplementedException();
        }

        public bool SetCommPassword(int CommKey)
        {
            throw new NotImplementedException();
        }

        public bool SetCustomizeAttState(int dwMachineNumber, int StateID, int NewState)
        {
            throw new NotImplementedException();
        }

        public bool SetCustomizeVoice(int dwMachineNumber, int VoiceID, string FileName)
        {
            throw new NotImplementedException();
        }

        public bool SetDaylight(int dwMachineNumber, int Support, string BeginTime, string EndTime)
        {
            throw new NotImplementedException();
        }

        public bool SetDeviceCommPwd(int dwMachineNumber, int CommKey)
        {
            throw new NotImplementedException();
        }

        public bool SetDeviceInfo(int dwMachineNumber, int dwInfo, int dwValue)
        {
            throw new NotImplementedException();
        }

        public bool SetDeviceIP(int dwMachineNumber, string IPAddr)
        {
            throw new NotImplementedException();
        }

        public bool SetDeviceMAC(int dwMachineNumber, string sMAC)
        {
            throw new NotImplementedException();
        }

        public bool SetDeviceTime(int dwMachineNumber)
        {
            throw new NotImplementedException();
        }

        public bool SetDeviceTime2(int dwMachineNumber, int dwYear, int dwMonth, int dwDay, int dwHour, int dwMinute, int dwSecond)
        {
            throw new NotImplementedException();
        }

        public bool SetEnrollData(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, int dwMachinePrivilege, ref int dwEnrollData, int dwPassWord)
        {
            throw new NotImplementedException();
        }

        public bool SetEnrollDataStr(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, int dwMachinePrivilege, string dwEnrollData, int dwPassWord)
        {
            throw new NotImplementedException();
        }

        public bool SetGroupTZs(int dwMachineNumber, int GroupIndex, ref int TZs)
        {
            throw new NotImplementedException();
        }

        public bool SetGroupTZStr(int dwMachineNumber, int GroupIndex, string TZs)
        {
            throw new NotImplementedException();
        }

        public bool SetHoliday(int dwMachineNumber, string Holiday)
        {
            throw new NotImplementedException();
        }

        public bool SetLanguageByID(int dwMachineNumber, int LanguageID, string Language)
        {
            throw new NotImplementedException();
        }

        public bool SetLastCount(int count)
        {
            throw new NotImplementedException();
        }

        public bool SetOptionCommPwd(int dwMachineNumber, string CommKey)
        {
            throw new NotImplementedException();
        }

        public bool SetSMS(int dwMachineNumber, int ID, int Tag, int ValidMinutes, string StartTime, string Content)
        {
            throw new NotImplementedException();
        }

        public bool SetStrCardNumber(string ACardNumber)
        {
            throw new NotImplementedException();
        }

        public bool SetSysOption(int dwMachineNumber, string Option, string Value)
        {
            throw new NotImplementedException();
        }

        public bool SetTZInfo(int dwMachineNumber, int TZIndex, string TZ)
        {
            throw new NotImplementedException();
        }

        public bool SetUnlockGroups(int dwMachineNumber, string Grps)
        {
            throw new NotImplementedException();
        }

        public bool SetUserFace(int dwMachineNumber, string dwEnrollNumber, int dwFaceIndex, ref byte TmpData, int TmpLength)
        {
            throw new NotImplementedException();
        }

        public bool SetUserFaceStr(int dwMachineNumber, string dwEnrollNumber, int dwFaceIndex, string TmpData, int TmpLength)
        {
            throw new NotImplementedException();
        }

        public bool SetUserGroup(int dwMachineNumber, int dwEnrollNumber, int UserGrp)
        {
            throw new NotImplementedException();
        }

        public bool SetUserInfo(int dwMachineNumber, int dwEnrollNumber, string Name, string Password, int Privilege, bool Enabled)
        {
            throw new NotImplementedException();
        }

        public bool SetUserInfoEx(int dwMachineNumber, int dwEnrollNumber, int VerifyStyle, ref byte Reserved)
        {
            throw new NotImplementedException();
        }

        public bool SetUserSMS(int dwMachineNumber, int dwEnrollNumber, int SMSID)
        {
            throw new NotImplementedException();
        }

        public bool SetUserTmp(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex, ref byte TmpData)
        {
            throw new NotImplementedException();
        }

        public bool SetUserTmpEx(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, int Flag, ref byte TmpData)
        {
            throw new NotImplementedException();
        }


        public bool SetUserTmpStr(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex, string TmpData)
        {
            throw new NotImplementedException();
        }

        public bool SetUserTZs(int dwMachineNumber, int dwEnrollNumber, ref int TZs)
        {
            throw new NotImplementedException();
        }

        public bool SetUserTZStr(int dwMachineNumber, int dwEnrollNumber, string TZs)
        {
            throw new NotImplementedException();
        }

        public bool SetWiegandFmt(int dwMachineNumber, string sWiegandFmt)
        {
            throw new NotImplementedException();
        }

        public bool SetWorkCode(int WorkCodeID, int AWorkCode)
        {
            throw new NotImplementedException();
        }

        public void set_AccTimeZones(int Index, int pVal)
        {
            throw new NotImplementedException();
        }

        public void set_CardNumber(int Index, int pVal)
        {
            throw new NotImplementedException();
        }

        public void set_STR_CardNumber(int Index, string pVal)
        {
            throw new NotImplementedException();
        }

        public bool SplitTemplate(ref byte Template, IntPtr Templates, ref int FingerCount, ref int FingerSize)
        {
            throw new NotImplementedException();
        }

        public bool SSR_ClearWorkCode()
        {
            throw new NotImplementedException();
        }

        public bool SSR_DeleteEnrollData(int dwMachineNumber, string dwEnrollNumber, int dwBackupNumber)
        {
            throw new NotImplementedException();
        }

        public bool SSR_DeleteEnrollDataExt(int dwMachineNumber, string dwEnrollNumber, int dwBackupNumber)
        {
            throw new NotImplementedException();
        }

        public bool SSR_DeleteUserSMS(int dwMachineNumber, string dwEnrollNumber, int SMSID)
        {
            throw new NotImplementedException();
        }

        public bool SSR_DeleteWorkCode(int PIN)
        {
            throw new NotImplementedException();
        }

        public bool SSR_DelUserTmp(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex)
        {
            throw new NotImplementedException();
        }

        public bool SSR_DelUserTmpExt(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex)
        {
            throw new NotImplementedException();
        }


        public bool SSR_GetDeviceData(int dwMachineNumber, out string Buffer, int BufferSize, string TableName, string FiledNames, string Filter, string Options)
        {
            throw new NotImplementedException();
        }


        public bool SSR_GetGroupTZ(int dwMachineNumber, int GroupNo, ref int Tz1, ref int Tz2, ref int Tz3, ref int VaildHoliday, ref int VerifyStyle)
        {
            throw new NotImplementedException();
        }

        public bool SSR_GetHoliday(int dwMachineNumber, int HolidayID, ref int BeginMonth, ref int BeginDay, ref int EndMonth, ref int EndDay, ref int TimeZoneID)
        {
            throw new NotImplementedException();
        }

        public bool SSR_GetShortkey(int ShortKeyID, ref int ShortKeyFun, ref int StateCode, ref string StateName, ref int AutoChange, ref string AutoChangeTime)
        {
            throw new NotImplementedException();
        }

        public bool SSR_GetSuperLogData(int MachineNumber, out int Number, out string Admin, out string User, out int Manipulation, out string Time, out int Params1, out int Params2, out int Params3)
        {
            throw new NotImplementedException();
        }

        public bool SSR_GetUnLockGroup(int dwMachineNumber, int CombNo, ref int Group1, ref int Group2, ref int Group3, ref int Group4, ref int Group5)
        {
            throw new NotImplementedException();
        }


        public bool SSR_GetUserTmp(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, out byte TmpData, out int TmpLength)
        {
            throw new NotImplementedException();
        }



        public bool SSR_GetWorkCode(int AWorkCode, out string Name)
        {
            throw new NotImplementedException();
        }

        public bool SSR_OutPutHTMLRep(int dwMachineNumber, string dwEnrollNumber, string AttFile, string UserFile, string DeptFile, string TimeClassFile, string AttruleFile, int BYear, int BMonth, int BDay, int BHour, int BMinute, int BSecond, int EYear, int EMonth, int EDay, int EHour, int EMinute, int ESecond, string TempPath, string OutFileName, int HTMLFlag, int resv1, string resv2)
        {
            throw new NotImplementedException();
        }

        public bool SSR_SetDeviceData(int dwMachineNumber, string TableName, string Datas, string Options)
        {
            throw new NotImplementedException();
        }

        public bool SSR_SetGroupTZ(int dwMachineNumber, int GroupNo, int Tz1, int Tz2, int Tz3, int VaildHoliday, int VerifyStyle)
        {
            throw new NotImplementedException();
        }

        public bool SSR_SetHoliday(int dwMachineNumber, int HolidayID, int BeginMonth, int BeginDay, int EndMonth, int EndDay, int TimeZoneID)
        {
            throw new NotImplementedException();
        }

        public bool SSR_SetShortkey(int ShortKeyID, int ShortKeyFun, int StateCode, string StateName, int StateAutoChange, string StateAutoChangeTime)
        {
            throw new NotImplementedException();
        }


        public bool SSR_SetUserSMS(int dwMachineNumber, string dwEnrollNumber, int SMSID)
        {
            throw new NotImplementedException();
        }

        public bool SSR_SetUserTmp(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, ref byte TmpData)
        {
            throw new NotImplementedException();
        }


        public bool SSR_SetUnLockGroup(int dwMachineNumber, int CombNo, int Group1, int Group2, int Group3, int Group4, int Group5)
        {
            throw new NotImplementedException();
        }


        public bool SSR_SetUserTmpExt(int dwMachineNumber, int IsDeleted, string dwEnrollNumber, int dwFingerIndex, ref byte TmpData)
        {
            throw new NotImplementedException();
        }

        public bool SSR_SetUserTmpStr(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, string TmpData)
        {
            throw new NotImplementedException();
        }

        public bool SSR_SetWorkCode(int AWorkCode, string Name)
        {
            throw new NotImplementedException();
        }


        public bool StartVerify(int UserID, int FingerID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFile(string FileName)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFirmware(string FirmwareFile)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLogo(int dwMachineNumber, string FileName)
        {
            throw new NotImplementedException();
        }

        public bool UseGroupTimeZone()
        {
            throw new NotImplementedException();
        }

        public bool WriteCard(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex1, ref byte TmpData1, int dwFingerIndex2, ref byte TmpData2, int dwFingerIndex3, ref byte TmpData3, int dwFingerIndex4, ref byte TmpData4)
        {
            throw new NotImplementedException();
        }

        public bool WriteCustData(int dwMachineNumber, string CustData)
        {
            throw new NotImplementedException();
        }

        public bool WriteLCD(int Row, int Col, string Text)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
