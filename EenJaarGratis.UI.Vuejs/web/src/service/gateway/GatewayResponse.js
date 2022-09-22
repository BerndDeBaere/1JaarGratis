export class GatewayResponse {
    constructor(isSuccess, data) {
        this.isSuccess = isSuccess;


        if(isSuccess) {
            this.data = data;
        }
        else if(data.code === "ERR_NETWORK"){
            this.data = "Server niet beschikbaar"
            console.log(data.config.method + " : " + data.config.url + "\n" + this.data)
        }
        else {
            this.data = data.response.data.message

            console.log(data.config.method + " : " + data.config.url + "\n" + this.data)
            console.log(data.response.data)

        }

    }


}