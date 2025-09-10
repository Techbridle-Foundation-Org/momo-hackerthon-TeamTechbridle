import { Card, CardContent } from "../components/Card";

export default function Investments() {
  return (
    <div className="p-6 space-y-6">
      <h1 className="text-2xl font-bold">Investments</h1>

      <div className="grid gap-6 md:grid-cols-3">
        <Card className="shadow-md rounded-2xl">
          <CardContent className="p-4">
            <h2 className="text-lg font-semibold">Real Estate</h2>
            <p className="text-sm text-gray-600">Total: R15,000</p>
            <p className="text-green-600 font-semibold mt-2">+8.5%</p>
          </CardContent>
        </Card>

        <Card className="shadow-md rounded-2xl">
          <CardContent className="p-4">
            <h2 className="text-lg font-semibold">Unit Trusts</h2>
            <p className="text-sm text-gray-600">Total: R6,500</p>
            <p className="text-green-600 font-semibold mt-2">+5.3%</p>
          </CardContent>
        </Card>

        <Card className="shadow-md rounded-2xl">
          <CardContent className="p-4">
            <h2 className="text-lg font-semibold">Money Market</h2>
            <p className="text-sm text-gray-600">Total: R3,000</p>
            <p className="text-green-600 font-semibold mt-2">+2.1%</p>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
