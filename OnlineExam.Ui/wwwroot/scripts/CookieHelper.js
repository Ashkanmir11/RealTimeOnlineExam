window.setAccessToken = function (property,value,expireDate) {
    alert(value);
    document.cookie = `${property}=${value};expiredate=${expireDate}`;
};