//*****************************************************************************
//** 1605. Find Valid Matrix Given Row and Column Sums                       **
//** Simple slow greedy algorithm                                       -Dan **
//*****************************************************************************


/**
 * Return an array of arrays of size *returnSize.
 * The sizes of the arrays are returned as *returnColumnSizes array.
 * Note: Both returned array and *columnSizes array must be malloced, assume caller calls free().
 */
int** restoreMatrix(int* rowSum, int rowSumSize, int* colSum, int colSumSize, int* returnSize, int** returnColumnSizes) {
    int** result = (int**)malloc(rowSumSize * sizeof(int*));
    *returnSize = rowSumSize;
    *returnColumnSizes = (int*)malloc(rowSumSize * sizeof(int));
    for (int i = 0; i < rowSumSize; i++) {
        result[i] = (int*)malloc(colSumSize * sizeof(int));
        memset(result[i], 0, colSumSize * sizeof(int)); // Initialize with zeros
        (*returnColumnSizes)[i] = colSumSize;
    }


    for(int i = 0; i < rowSumSize; i++)
    {
        for(int j = 0; j < colSumSize; j++)
        {

            if(rowSum[i] < colSum[j])
                result[i][j] = rowSum[i];
            else
                result[i][j] = colSum[j];
            rowSum[i] -= result[i][j];
            colSum[j] -= result[i][j];
        }
    }
    return result;
}