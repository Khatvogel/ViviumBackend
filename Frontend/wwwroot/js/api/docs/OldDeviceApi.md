# ViviumApi.OldDeviceApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**deprecatedDeviceGet**](OldDeviceApi.md#deprecatedDeviceGet) | **GET** /deprecated/device | 
[**deprecatedDevicePingPatch**](OldDeviceApi.md#deprecatedDevicePingPatch) | **PATCH** /deprecated/device/ping | 
[**deprecatedDeviceRegisterPost**](OldDeviceApi.md#deprecatedDeviceRegisterPost) | **POST** /deprecated/device/register | 



## deprecatedDeviceGet

> deprecatedDeviceGet()



### Example

```javascript
import ViviumApi from 'vivium_api';

let apiInstance = new ViviumApi.OldDeviceApi();
apiInstance.deprecatedDeviceGet((error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
});
```

### Parameters

This endpoint does not need any parameter.

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined


## deprecatedDevicePingPatch

> deprecatedDevicePingPatch(opts)



### Example

```javascript
import ViviumApi from 'vivium_api';

let apiInstance = new ViviumApi.OldDeviceApi();
let opts = {
  'device': new ViviumApi.Device() // Device | 
};
apiInstance.deprecatedDevicePingPatch(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
});
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **device** | [**Device**](Device.md)|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/_*+json, application/json-patch+json
- **Accept**: Not defined


## deprecatedDeviceRegisterPost

> deprecatedDeviceRegisterPost(opts)



### Example

```javascript
import ViviumApi from 'vivium_api';

let apiInstance = new ViviumApi.OldDeviceApi();
let opts = {
  'device': new ViviumApi.Device() // Device | 
};
apiInstance.deprecatedDeviceRegisterPost(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
});
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **device** | [**Device**](Device.md)|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/_*+json, application/json-patch+json
- **Accept**: Not defined

