import React from "react";

const Dashboard: React.FC = () => {
  return (
    <div>
      <h1 className="text-2xl font-bold mb-4">Stockvel Dashboard</h1>
      <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
        <div className="bg-white p-4 rounded-xl shadow">Total Savings: R24,500</div>
        <div className="bg-white p-4 rounded-xl shadow">Monthly Contributions: R1,200</div>
        <div className="bg-white p-4 rounded-xl shadow">Investment Returns: +12.5%</div>
      </div>
      <div className="mt-6 bg-white p-4 rounded-xl shadow">
        <h2 className="text-lg font-semibold mb-2">Recent Activity</h2>
        <ul className="list-disc pl-6">
          <li>Payment received - R500</li>
          <li>Group investment added - R1,200</li>
          <li>Member joined "Family Savings"</li>
        </ul>
      </div>
    </div>
  );
};

export default Dashboard;
