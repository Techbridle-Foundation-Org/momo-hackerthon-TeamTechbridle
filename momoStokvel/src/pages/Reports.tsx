import { Card, CardContent } from "../components/Card";

export default function Reports() {
  return (
    <div className="p-6 space-y-6">
      <h1 className="text-2xl font-bold">Reports</h1>

      <div className="grid gap-6 md:grid-cols-2">
        <Card className="shadow-md rounded-2xl">
          <CardContent className="p-4">
            <h2 className="text-lg font-semibold">Contribution Summary</h2>
            <p className="text-sm text-gray-600">Total Contributions: R24,500</p>
          </CardContent>
        </Card>

        <Card className="shadow-md rounded-2xl">
          <CardContent className="p-4">
            <h2 className="text-lg font-semibold">Investment Returns</h2>
            <p className="text-sm text-gray-600">+12.5% this year</p>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
