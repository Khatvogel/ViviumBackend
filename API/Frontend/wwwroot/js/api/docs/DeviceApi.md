# ViviumApi.DeviceApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**devicesFinishGet**](DeviceApi.md#devicesFinishGet) | **GET** /devices/finish | 
[**devicesGet**](DeviceApi.md#devicesGet) | **GET** /devices | 
[**devicesRegisterPost**](DeviceApi.md#devicesRegisterPost) | **POST** /devices/register | 



## devicesFinishGet

> devicesFinishGet(opts)



### Example

```javascript
import ViviumApi from 'vivium_api';

let apiInstance = new ViviumApi.DeviceApi();
let opts = {
  'macAddress': "macAddress_example" // String | 
};
apiInstance.devicesFinishGet(opts, (error, data, response) => {
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
 **macAddress** | **String**|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined


## devicesGet

> devicesGet()



### Example

```javascript
import ViviumApi from 'vivium_api';

let apiInstance = new ViviumApi.DeviceApi();
apiInstance.devicesGet((error, data, response) => {
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


## devicesRegisterPost

> devicesRegisterPost(opts)



### Example

```javascript
import ViviumApi from 'vivium_api';

let apiInstance = new ViviumApi.DeviceApi();
let opts = {
  'device': new ViviumApi.Device() // Device | 
};
apiInstance.devicesRegisterPost(opts, (error, data, response) => {
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

