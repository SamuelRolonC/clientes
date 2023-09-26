function useAppParameters() {
    const apiBaseUrl = 'https://localhost:44352';

    const apiCustomerController = '/customer';

    const apiCustomerUrl = apiBaseUrl + apiCustomerController;

    const getApiCustomerAllUrl = () => apiCustomerUrl + '/all'
        , getApiCustomerGetUrl = (id) => apiCustomerUrl + '?id=' + id
        , getApiCustomerPutPostUrl = () => apiCustomerUrl
        , getApiCustomerSearchUrl = (name) => apiCustomerUrl + '/search?name=' + name;

    const getAppCustomerGridNavigate = () => '/Customer'
        , getAppCustomerEditCreateNavigate = (id) => '/Customer/' + id;
    

    return {
        getApiCustomerAllUrl
        , getApiCustomerGetUrl
        , getApiCustomerPutPostUrl
        , getApiCustomerSearchUrl
        , getAppCustomerGridNavigate
        , getAppCustomerEditCreateNavigate
    }
}

export { useAppParameters };