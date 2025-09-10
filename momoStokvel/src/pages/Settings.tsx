import { Card, CardContent } from "../components/Card";
import { Button } from "../components/Buttons";


export default function Settings() {
  return (
    <div className="p-6 space-y-6">
      <h1 className="text-2xl font-bold">Settings</h1>

      <Card className="shadow-md rounded-2xl">
        <CardContent className="p-4 space-y-4">
          <div>
            <h2 className="text-lg font-semibold">Profile</h2>
            <p className="text-sm text-gray-600">Manage your account details</p>
          </div>
          <Button>Edit Profile</Button>
        </CardContent>
      </Card>

      <Card className="shadow-md rounded-2xl">
        <CardContent className="p-4 space-y-4">
          <div>
            <h2 className="text-lg font-semibold">Notifications</h2>
            <p className="text-sm text-gray-600">Choose how you want to be notified</p>
          </div>
          <Button>Manage Notifications</Button>
        </CardContent>
      </Card>
    </div>
  );
}
