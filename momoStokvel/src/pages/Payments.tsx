import { Card, CardContent } from "../components/Card";
import { Button } from "@/components/ui/button";

export default function Payments() {
  return (
    <div className="p-6 space-y-6">
      <h1 className="text-2xl font-bold">Payments</h1>

      <div className="grid gap-4">
        <Card className="shadow-md rounded-2xl">
          <CardContent className="p-4 flex justify-between items-center">
            <div>
              <p className="text-lg font-semibold">Contribution - Family Savings</p>
              <p className="text-sm text-gray-600">Due: 15 Sep 2025 · R500</p>
            </div>
            <Button>Pay</Button>
          </CardContent>
        </Card>

        <Card className="shadow-md rounded-2xl">
          <CardContent className="p-4 flex justify-between items-center">
            <div>
              <p className="text-lg font-semibold">Contribution - Investment Club</p>
              <p className="text-sm text-gray-600">Due: 20 Sep 2025 · R1,200</p>
            </div>
            <Button>Pay</Button>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
