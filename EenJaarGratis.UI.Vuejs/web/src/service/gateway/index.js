import playerGateway from "@/service/gateway/playerGateway";
import questionGateway from "@/service/gateway/questionGateway";
import {GatewayResponse} from "@/service/gateway/GatewayResponse";
import controlGateway from "@/service/gateway/controlGateway";


export default {
    Players: playerGateway,
    Questions: questionGateway,
    Controls: controlGateway,

    GatewayResponse: GatewayResponse
}