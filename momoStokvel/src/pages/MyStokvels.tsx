import { Card, CardContent } from "../components/Card";
import { Button } from "../components/Buttons";

export default function MyStockvel() {
  return (
    <div className="p-6 space-y-6">
      <h1 className="text-2xl font-bold">My Stockvel Groups</h1>

      <div className="grid gap-4">
        <Card className="shadow-md rounded-2xl">
          <CardContent className="p-4 flex justify-between items-center">
            <div>
              <h2 className="text-lg font-semibold">Family Savings</h2>
              <p className="text-sm text-gray-600">5 members · Monthly R1,000</p>
            </div>
            <Button>View</Button>
          </CardContent>
        </Card>

        <Card className="shadow-md rounded-2xl">
          <CardContent className="p-4 flex justify-between items-center">
            <div>
              <h2 className="text-lg font-semibold">Investment Club</h2>
              <p className="text-sm text-gray-600">8 members · Monthly R2,000</p>
            </div>
            <Button>View</Button>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
