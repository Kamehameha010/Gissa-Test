

export class HttpRequest {
    static async SendASync(objRequest) {
        const request = await fetch(objRequest);
        return await request.json()
    }
}