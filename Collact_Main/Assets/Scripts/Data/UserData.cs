using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
    public class UserInfo {
        private string _userName;
        private int _year;
        private float _saturation;

        public UserInfo(string userName, int year, float saturation) {
            _userName = userName;
            _year = year;
            _saturation = saturation;
        }
    }

public class UserData {

    public List<List<UserInfo>> userInfo = new List<List<UserInfo>>();

    public void addUserData(string userName, int field, int year, float saturation) {
        UserInfo newInfo = new UserInfo(userName, year, saturation);
        userInfo[field - 1].Add(newInfo);
    }

    public List<UserInfo> getSameFieldUserDataList(int field) {
        return userInfo[field - 1];
    }
}