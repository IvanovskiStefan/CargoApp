import "./App.css";
import { useState } from "react";

function App() {
  const [parcels, setParcels] = useState();
  const [parcelName, setparcelName] = useState();
  const [parcelWidth, setparcelWidth] = useState();
  const [parcelHeight, setparcelHeight] = useState();
  const [parcelDepth, setparcelDepth] = useState();
  const [parcelWeight, setparcelWeight] = useState();
  const [finalPrice, setFinalPrice] = useState();

  //getting all parcels fetch
  const getAllParcels = () => {
    fetch("https://localhost:7093/api/v1/Parcel/get-all")
      .then((res) => res.json())
      .then((data) => setParcels(data));
    // .then(data => console.log(data))// console log za fetch da vidis dali raboti prost eden@!
  };

  const getDimensions = async () => {
    let cargo4uPrice;
    let shipFasterPrice;
    let maltashipPrice;
    await fetch(`https://localhost:7093/api/Calculaiton/calculation-cargo4u`, {
      method: "POST",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        parcelWeight: parcelWeight,
        parcelWidth: parcelWidth,
        parcelHeight: parcelHeight,
        parcelDepth: parcelDepth,
      }),
    })
      .then((res) => res.json())
      .then((data) => (cargo4uPrice = data));

    await fetch(
      `https://localhost:7093/api/Calculaiton/calculation-shipfaster`,
      {
        method: "POST",
        credentials: "same-origin",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          parcelWeight: parcelWeight,
          parcelWidth: parcelWidth,
          parcelHeight: parcelHeight,
          parcelDepth: parcelDepth,
        }),
      }
    )
      .then((res) => res.json())
      .then((data) => (shipFasterPrice = data));

    await fetch(
      `https://localhost:7093/api/Calculaiton/calculation-maltaship`,
      {
        method: "POST",
        credentials: "same-origin",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          parcelWeight: parcelWeight,
          parcelWidth: parcelWidth,
          parcelHeight: parcelHeight,
          parcelDepth: parcelDepth,
        }),
      }
    )
      .then((res) => res.json())
      .then((data) => (maltashipPrice = data));

    const finalPriceBackend = await Math.min(
      cargo4uPrice,
      shipFasterPrice,
      maltashipPrice
    );
    setFinalPrice(finalPriceBackend);

    await fetch(`https://localhost:7093/api/v1/Parcel/add-parcel`, {
      method: "POST",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        parcelWeight: parcelWeight,
        parcelWidth: parcelWidth,
        parcelHeight: parcelHeight,
        parcelDepth: parcelDepth,
        parcelFinalPrice: await JSON.stringify(finalPriceBackend),
        parcelName: parcelName,
      }),
    });
  };

  return (
    <div className="main-div">
      <h1>Get the best shipping deal per volumeN</h1>
      <div className="input-information-container">
        <div className="input-container">
          <input
            className="input-field"
            placeholder="enter parcel width"
            name="parcelWidth"
            value={parcelWidth}
            type="number"
            onChange={(e) => {
              setparcelWidth(e.target.value);
            }}
          />
          <input
            className="input-field"
            placeholder="enter parcel height"
            name="parcelHeight"
            value={parcelHeight}
            type="number"
            onChange={(e) => {
              setparcelHeight(e.target.value);
            }}
          />
          <input
            className="input-field"
            placeholder="enter parcel depth"
            name="parcelDepth"
            value={parcelDepth}
            type="number"
            onChange={(e) => {
              setparcelDepth(e.target.value);
            }}
          />
          <input
            className="input-field"
            placeholder="enter parcel weight"
            name="parcelWeight"
            value={parcelWeight}
            type="number"
            onChange={(e) => {
              setparcelWeight(e.target.value);
            }}
          />
          <input
            className="input-field"
            placeholder="enter parcel name"
            name="parcelname"
            value={parcelName}
            type="text"
            onChange={(e) => {
              setparcelName(e.target.value);
            }}
          />
          <button onClick={getDimensions}> get shipping price</button>
        </div>
        <div className="information-price">
          The best price for this shippment is : {finalPrice}
        </div>
      </div>
      <div className="parcel-information-div">
        <div className="button-div">
          <button onClick={getAllParcels}>Get all parcels</button>
        </div>
        <div className="print-information">
          {parcels &&
            parcels.map((parcel) => {
              return (
                <div key={parcel.name}>
                  Parcel name : {parcel.parcelName}
                  Parcel price : {parcel.parcelFinalPrice}
                </div>
              );
            })}
        </div>
      </div>
    </div>
  );
}

export default App;
