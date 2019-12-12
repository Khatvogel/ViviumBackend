# ViviumApi.AttemptApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**attemptsGet**](AttemptApi.md#attemptsGet) | **GET** /attempts | 
[**attemptsStartGet**](AttemptApi.md#attemptsStartGet) | **GET** /attempts/start | 



## attemptsGet

> attemptsGet()



### Example

```javascript
import ViviumApi from 'vivium_api';

let apiInstance = new ViviumApi.AttemptApi();
apiInstance.attemptsGet((error, data, response) => {
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


## attemptsStartGet

> attemptsStartGet()



### Example

```javascript
import ViviumApi from 'vivium_api';

let apiInstance = new ViviumApi.AttemptApi();
apiInstance.attemptsStartGet((error, data, response) => {
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

