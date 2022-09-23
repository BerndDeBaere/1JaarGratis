import playerGateway from "@/service/gateway/playerGateway";
import questionGateway from "@/service/gateway/questionGateway";
import {GatewayResponse} from "@/service/gateway/GatewayResponse";


export default {
    Players: playerGateway,
    Questions: questionGateway,
    GatewayResponse: GatewayResponse
}