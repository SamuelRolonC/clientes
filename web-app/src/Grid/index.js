import React, { useEffect } from "react";
import { useState } from "react";
import './Grid.css';
import { useNavigate } from "react-router-dom";
import { useAppParameters } from "../Utils/useAppParameters";

function Grid() {
    const [data, setData] = useState([]);
    const navigate = useNavigate();
    const { getApiCustomerAllUrl, getAppCustomerEditCreateNavigate } = useAppParameters();

    const getData = () => {
        fetch(getApiCustomerAllUrl(), {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(response => response.json())
        .then(data => {
            console.log('Success');
            setData(data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    }

    useEffect(() => {
        getData();
    }, []);

    const onClickCustomer = (id) => {
        navigate(getAppCustomerEditCreateNavigate(id));
    }

    return (
        <div className='Grid'>
            <h2>Clientes</h2>
            <button onClick={() => onClickCustomer(0)}>Nuevo</button>
            <table className="tableGrid center">
                <tr className="tableHeader">
                    <th>ID</th>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>CUIT</th>
                    <th></th>
                </tr>
                {data.map((item, index) => (
                    <tr className="tableRow" key={index}>
                        <td>{item.id}</td>
                        <td>{item.name}</td>
                        <td>{item.surname}</td>
                        <td>{item.cuit}</td>
                        <td>
                            <button onClick={() => onClickCustomer(item.id)}>Editar</button>
                        </td>
                    </tr>
                ))}
            </table>
        </div>
    );
}

export { Grid };